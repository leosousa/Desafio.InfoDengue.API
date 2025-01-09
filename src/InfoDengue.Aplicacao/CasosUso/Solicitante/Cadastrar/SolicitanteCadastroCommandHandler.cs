using AutoMapper;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Aplicacao.Servicos;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;
using InfoDengue.Dominio.Enumeracoes;
using InfoDengue.Dominio.Recursos;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Solicitante.Cadastrar;

public class SolicitanteCadastroCommandHandler : ServicoAplicacao,
    IRequestHandler<SolicitanteCadastroCommand, Result<SolicitanteCadastroCommandResult>>
{
    private readonly IMapper _mapper;
    private readonly IServicoCadastroSolicitante _servicoCadastroUsuario;
    private readonly IServicoBuscaSolicitantePorCpf _servicoBuscaUsuarioPorCpf;

    public SolicitanteCadastroCommandHandler(
        IMapper mapper,
        IServicoCadastroSolicitante servicoCadastroUsuario,
        IServicoBuscaSolicitantePorCpf servicoBuscaUsuarioPorCpf)
    {
        _mapper = mapper;
        _servicoCadastroUsuario = servicoCadastroUsuario;
        _servicoBuscaUsuarioPorCpf = servicoBuscaUsuarioPorCpf;
    }

    public async Task<Result<SolicitanteCadastroCommandResult>> Handle(SolicitanteCadastroCommand request, CancellationToken cancellationToken)
    {
        Result<SolicitanteCadastroCommandResult> result = new();

        var usuario = _mapper.Map<Dominio.Entidades.Solicitante>(request);

        var usuarioJaCadastrado = await _servicoBuscaUsuarioPorCpf.BuscarPorCpfAsync(usuario.Cpf, cancellationToken);

        if (usuarioJaCadastrado is not null)
        {
            result.AddResultadoAcao(EResultadoAcaoServico.ParametrosInvalidos);
            result.AddNotification(nameof(Dominio.Entidades.Solicitante), Mensagens.SolicitanteJaCadastrado);

            return await Task.FromResult(result);
        }

        var usuarioCadastrado = await _servicoCadastroUsuario.CadastrarAsync(usuario, cancellationToken);

        result.AddResultadoAcao(_servicoCadastroUsuario.ResultadoAcao);
        result.AddNotifications(_servicoCadastroUsuario.Notifications);

        if (_servicoCadastroUsuario.ResultadoAcao != Dominio.Enumeracoes.EResultadoAcaoServico.Suceso)
        {
            return await Task.FromResult(result);
        }

        result.Data = _mapper.Map<SolicitanteCadastroCommandResult>(usuarioCadastrado);

        return await Task.FromResult(result);
    }
}