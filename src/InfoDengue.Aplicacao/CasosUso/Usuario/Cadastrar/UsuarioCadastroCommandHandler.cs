using AutoMapper;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Aplicacao.Servicos;
using InfoDengue.Dominio.Contratos.Servicos.Usuario;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Usuario.Cadastrar;

public class UsuarioCadastroCommandHandler : ServicoAplicacao,
    IRequestHandler<UsuarioCadastroCommand, Result<UsuarioCadastroCommandResult>>
{
    private readonly IMapper _mapper;
    private readonly IServicoCadastroUsuario _servicoCadastroUsuario;

    public UsuarioCadastroCommandHandler(
        IMapper mapper,
        IServicoCadastroUsuario servicoCadastroUsuario)
    {
        _mapper = mapper;
        _servicoCadastroUsuario = servicoCadastroUsuario;
    }

    public async Task<Result<UsuarioCadastroCommandResult>> Handle(UsuarioCadastroCommand request, CancellationToken cancellationToken)
    {
        Result<UsuarioCadastroCommandResult> result = new();

        var assunto = _mapper.Map<Dominio.Entidades.Usuario>(request);

        var assuntoCadastrado = await _servicoCadastroUsuario.CadastrarAsync(assunto, cancellationToken);

        result.AddResultadoAcao(_servicoCadastroUsuario.ResultadoAcao);
        result.AddNotifications(_servicoCadastroUsuario.Notifications);

        if (_servicoCadastroUsuario.ResultadoAcao != Dominio.Enumeracoes.EResultadoAcaoServico.Suceso)
        {
            return await Task.FromResult(result);
        }

        result.Data = _mapper.Map<UsuarioCadastroCommandResult>(assuntoCadastrado);

        return await Task.FromResult(result);
    }
}