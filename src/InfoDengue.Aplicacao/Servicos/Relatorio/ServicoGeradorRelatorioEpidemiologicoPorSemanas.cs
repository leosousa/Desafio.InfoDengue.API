using AutoMapper;
using InfoDengue.Aplicacao.Contratos;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Dominio.Contratos.Servicos.Municipio;
using InfoDengue.Dominio.Contratos.Servicos.Relatorio;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;
using InfoDengue.Dominio.Recursos;
using InfoDengue.Dominio.Servicos.Municipio;
using InfoDengue.Infraestrutura.Integracao.Contratos;
using InfoDengue.Infraestrutura.Integracao.Helpers;

namespace InfoDengue.Aplicacao.Servicos.Relatorio;

public class ServicoGeradorRelatorioEpidemiologicoPorSemanas : IServicoGeradorRelatorioEpidemiologicoPorSemanas
{
    private readonly IMapper _mapper;
    private readonly IServicoBuscaSolicitantePorCpf _servicoBuscaSolicitantePorCpf;
    private readonly IServicoCadastroSolicitante _servicoCadastroSolicitante;
    private readonly IServicoBuscaMunicipioPorCodigo _servicoBuscaMunicipioPorCodigo;
    private readonly IServicoCalculadoraSemana _servicoCalculadoraSemana;
    private readonly IServicoRelatorioAlerta _servicoRelatorioAlerta;
    private readonly IServicoCadastroRelatorio _servicoCadastroRelatorio;

    public ServicoGeradorRelatorioEpidemiologicoPorSemanas(
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

    public async Task<Result<RelatorioEpidemiologicoSemanasCommandResult>> GerarRelatorioEpidemiologico(RelatorioEpidemiologicoSemanasCommand parametros, CancellationToken cancellationToken)
    {
        Result<RelatorioEpidemiologicoSemanasCommandResult> result = new();

        if (parametros is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoSemanasCommand), Mensagens.ParametrosNaoInformados);

            return await Task.FromResult(result);
        }

        if (parametros.Solicitante is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoSemanasCommand.Solicitante), Mensagens.SolicitanteNaoInformado);

            return await Task.FromResult(result);
        }

        var solicitanteValidado = await ValidarSolicitante(parametros.Solicitante, result, cancellationToken);

        if (!result.IsValid)
        {
            return await Task.FromResult(result);
        }

        if (solicitanteValidado is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.Erro);

            result.AddNotification(nameof(RelatorioEpidemiologicoSemanasCommand.Solicitante), Mensagens.OcorreuUmErroAoCadastrarSolicitante);

            return await Task.FromResult(result);
        }

        if (parametros.CodigoIbge < 0)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoSemanasCommand.CodigoIbge), Mensagens.CodigoIbgeNaoInformado);

            return await Task.FromResult(result);
        }

        var municipioEncontrado = await _servicoBuscaMunicipioPorCodigo.BuscarPorCodigoAsync(parametros.CodigoIbge, cancellationToken);

        if (municipioEncontrado is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.NaoEncontrado);

            result.AddNotification(nameof(RelatorioEpidemiologicoSemanasCommand.CodigoIbge), Mensagens.CodigoIbgeNaoEncontrado);

            return await Task.FromResult(result);
        }

        if (parametros.SemanaTermino < parametros.SemanaInicio)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoSemanasCommand.SemanaTermino), Mensagens.SemanaTerminoPrecisaSerPosteriorSemanaInicio);

            return await Task.FromResult(result);
        }

        if (parametros.AnoTermino < parametros.AnoInicio)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoSemanasCommand.AnoTermino), Mensagens.AnoTerminoPrecisaSerPosteriorAnoInicio);

            return await Task.FromResult(result);
        }

        var relatorio = await _servicoRelatorioAlerta.ObterRelatorio(municipioEncontrado.CodigoIbge, parametros.Arbovirose, parametros.SemanaInicio, parametros.SemanaTermino, parametros.AnoInicio, parametros.AnoTermino);

        if (relatorio is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.NaoEncontrado);

            result.AddNotification(nameof(Relatorio), Mensagens.NenhumDadoEncontrado);

            return await Task.FromResult(result);
        }

        result.Data = _mapper.Map<RelatorioEpidemiologicoSemanasCommandResult>(relatorio);

        var relatorioRegistrado = new Dominio.Entidades.Relatorio(dataSolicitacao: DateTime.Now, parametros.Arbovirose, parametros.SemanaInicio, parametros.SemanaTermino, municipioEncontrado.Id, solicitanteValidado.Id);

        var relatorioCadastrado = await _servicoCadastroRelatorio.CadastrarAsync(relatorioRegistrado, cancellationToken);

        if (relatorioCadastrado is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.Erro);

            result.AddNotification(nameof(Dominio.Entidades.Relatorio), Mensagens.OcorreuUmErroAoCadastrarRelatorio);

            return await Task.FromResult(result);
        }

        result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.Sucesso);

        return await Task.FromResult(result);
    }

    private async Task<Dominio.Entidades.Solicitante?> ValidarSolicitante(SolicitanteDto solicitante, Result<RelatorioEpidemiologicoSemanasCommandResult> result, CancellationToken cancellationToken)
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