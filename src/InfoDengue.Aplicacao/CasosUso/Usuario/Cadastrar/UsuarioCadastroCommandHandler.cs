using AutoMapper;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Aplicacao.Servicos;
using InfoDengue.Dominio.Contratos.Servicos.Usuario;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Dominio.Enumeracoes;
using InfoDengue.Dominio.Recursos;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Usuario.Cadastrar;

public class UsuarioCadastroCommandHandler : ServicoAplicacao,
    IRequestHandler<UsuarioCadastroCommand, Result<UsuarioCadastroCommandResult>>
{
    private readonly IMapper _mapper;
    private readonly IServicoCadastroUsuario _servicoCadastroUsuario;
    private readonly IServicoBuscaUsuarioPorCpf _servicoBuscaUsuarioPorCpf;

    public UsuarioCadastroCommandHandler(
        IMapper mapper,
        IServicoCadastroUsuario servicoCadastroUsuario,
        IServicoBuscaUsuarioPorCpf servicoBuscaUsuarioPorCpf)
    {
        _mapper = mapper;
        _servicoCadastroUsuario = servicoCadastroUsuario;
        _servicoBuscaUsuarioPorCpf = servicoBuscaUsuarioPorCpf;
    }

    public async Task<Result<UsuarioCadastroCommandResult>> Handle(UsuarioCadastroCommand request, CancellationToken cancellationToken)
    {
        Result<UsuarioCadastroCommandResult> result = new();

        var usuario = _mapper.Map<Dominio.Entidades.Usuario>(request);

        var usuarioJaCadastrado = await _servicoBuscaUsuarioPorCpf.BuscarPorCpfAsync(usuario.Cpf, cancellationToken);

        if (usuarioJaCadastrado is not null)
        {
            result.AddResultadoAcao(EResultadoAcaoServico.ParametrosInvalidos);
            result.AddNotification(nameof(Dominio.Entidades.Usuario), Mensagens.UsuarioJaCadastrado);

            return await Task.FromResult(result);
        }

        var usuarioCadastrado = await _servicoCadastroUsuario.CadastrarAsync(usuario, cancellationToken);

        result.AddResultadoAcao(_servicoCadastroUsuario.ResultadoAcao);
        result.AddNotifications(_servicoCadastroUsuario.Notifications);

        if (_servicoCadastroUsuario.ResultadoAcao != Dominio.Enumeracoes.EResultadoAcaoServico.Suceso)
        {
            return await Task.FromResult(result);
        }

        result.Data = _mapper.Map<UsuarioCadastroCommandResult>(usuarioCadastrado);

        return await Task.FromResult(result);
    }
}