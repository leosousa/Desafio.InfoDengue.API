using AutoMapper;
using InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorMunicipio.BuscarRelatorioPorMunicipio;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Aplicacao.Servicos;
using InfoDengue.Dominio.Contratos.Servicos.Municipio;
using InfoDengue.Dominio.Contratos.Servicos.Relatorio;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Dominio.Recursos;
using InfoDengue.Infraestrutura.Integracao.Contratos;
using InfoDengue.Infraestrutura.Integracao.Helpers;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorCodigoIbge;

internal class RelatorioEpidemiologicoPorCodigoIbgeCommandHandler : ServicoAplicacao,
    IRequestHandler<RelatorioEpidemiologicoPorCodigoIbgeCommand, Result<RelatorioEpidemiologicoPorCodigoIbgeCommandResult>>
{
    private readonly IMapper _mapper;
    private readonly IServicoBuscaSolicitantePorCpf _servicoBuscaSolicitantePorCpf;
    private readonly IServicoCadastroSolicitante _servicoCadastroSolicitante;
    private readonly IServicoBuscaMunicipioPorCodigo _servicoBuscaMunicipioPorCodigo;
    private readonly IServicoCalculadoraSemana _servicoCalculadoraSemana;
    private readonly IServicoRelatorioAlerta _servicoRelatorioAlerta;
    private readonly IServicoCadastroRelatorio _servicoCadastroRelatorio;

    public RelatorioEpidemiologicoPorCodigoIbgeCommandHandler(
        IMapper mapper,
        IServicoBuscaSolicitantePorCpf servicoBuscaSolicitantePorCpf,
        IServicoCadastroSolicitante servicoCadastroSolicitante,
        IServicoBuscaMunicipioPorCodigo servicoBuscaMunicipioPorCodigo,
        IServicoCalculadoraSemana servicoCalculadoraSemana,
        IServicoRelatorioAlerta servicoRelatorioAlerta,
        IServicoCadastroRelatorio servicoCadastroRelatorio)
    {
        _mapper = mapper;
        _servicoBuscaSolicitantePorCpf = servicoBuscaSolicitantePorCpf;
        _servicoCadastroSolicitante = servicoCadastroSolicitante;
        _servicoBuscaMunicipioPorCodigo = servicoBuscaMunicipioPorCodigo;
        _servicoCalculadoraSemana = servicoCalculadoraSemana;
        _servicoRelatorioAlerta = servicoRelatorioAlerta;
        _servicoCadastroRelatorio = servicoCadastroRelatorio;
    }

    public async Task<Result<RelatorioEpidemiologicoPorCodigoIbgeCommandResult>> Handle(RelatorioEpidemiologicoPorCodigoIbgeCommand command, CancellationToken cancellationToken)
    {
        Result<RelatorioEpidemiologicoPorCodigoIbgeCommandResult> result = new();

        if (command is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorCodigoIbgeCommand), Mensagens.ParametrosNaoInformados);

            return await Task.FromResult(result);
        }

        if (command.Solicitante is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorCodigoIbgeCommand.Solicitante), Mensagens.SolicitanteNaoInformado);

            return await Task.FromResult(result);
        }

        var solicitanteValidado = await ValidarSolicitante(command.Solicitante, result, cancellationToken);

        if (!result.IsValid)
        {
            return await Task.FromResult(result);
        }

        if (solicitanteValidado is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.Erro);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorCodigoIbgeCommand.Solicitante), Mensagens.OcorreuUmErroAoCadastrarSolicitante);

            return await Task.FromResult(result);
        }

        if (command.CodigoIbge < 0)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorCodigoIbgeCommand.CodigoIbge), Mensagens.CodigoIbgeNaoInformado);

            return await Task.FromResult(result);
        }

        var municipioEncontrado = await _servicoBuscaMunicipioPorCodigo.BuscarPorCodigoAsync(command.CodigoIbge, cancellationToken);

        if (municipioEncontrado is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.NaoEncontrado);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorCodigoIbgeCommand.CodigoIbge), Mensagens.CodigoIbgeNaoEncontrado);

            return await Task.FromResult(result);
        }

        if (command.DataTermino < command.DataInicio)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorCodigoIbgeCommand.DataTermino), Mensagens.DataTerminoPrecisaSerPosteriorDataInicio);

            return await Task.FromResult(result);
        }

        var semanaInicio = await _servicoCalculadoraSemana.CalcularSemana(command.DataInicio);

        var semanaTermino = await _servicoCalculadoraSemana.CalcularSemana(command.DataTermino);

        var relatorio = await _servicoRelatorioAlerta.ObterRelatorio(municipioEncontrado.CodigoIbge, command.Arbovirose, semanaInicio, semanaTermino, command.DataInicio.Year, command.DataTermino.Year);

        if (relatorio is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.NaoEncontrado);

            result.AddNotification(nameof(Relatorio), Mensagens.NenhumDadoEncontrado);

            return await Task.FromResult(result);
        }

        result.Data = _mapper.Map<RelatorioEpidemiologicoPorCodigoIbgeCommandResult>(relatorio);

        var relatorioRegistrado = new Relatorio(dataSolicitacao: DateTime.Now, command.Arbovirose, semanaInicio, semanaTermino, municipioEncontrado.Id, solicitanteValidado.Id);

        var relatorioCadastrado = await _servicoCadastroRelatorio.CadastrarAsync(relatorioRegistrado, cancellationToken);

        if (relatorioCadastrado is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.Erro);

            result.AddNotification(nameof(Relatorio), Mensagens.OcorreuUmErroAoCadastrarRelatorio);

            return await Task.FromResult(result);
        }

        result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.Sucesso);

        return await Task.FromResult(result);
    }

    private async Task<Dominio.Entidades.Solicitante?> ValidarSolicitante(RelatorioEpidemiologicoPorCodigoSolicitante solicitante, Result<RelatorioEpidemiologicoPorCodigoIbgeCommandResult> result, CancellationToken cancellationToken)
    {
        var solicitanteJaCadastrado = await _servicoBuscaSolicitantePorCpf.BuscarPorCpfAsync(solicitante.Cpf, cancellationToken);

        if (solicitanteJaCadastrado is null)
        {
            solicitanteJaCadastrado = await _servicoCadastroSolicitante.CadastrarAsync(
                new Dominio.Entidades.Solicitante(solicitante.Nome, solicitante.Cpf),
                cancellationToken);

            if (!_servicoCadastroSolicitante.IsValid)
            {
                result.AddResultadoAcao(_servicoCadastroSolicitante.ResultadoAcao);

                result.AddNotifications(_servicoCadastroSolicitante.Notifications);
            }
        }

        return solicitanteJaCadastrado;
    }
}
