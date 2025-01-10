using AutoMapper;
using InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorMunicipio.BuscarRelatorioPorMunicipio;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Dominio.Contratos.Servicos.Municipio;
using InfoDengue.Dominio.Contratos.Servicos.Relatorio;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Dominio.Recursos;
using InfoDengue.Infraestrutura.Integracao.Contratos;
using InfoDengue.Infraestrutura.Integracao.Helpers;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorMunicipio;

public class RelatorioEpidemiologicoPorMunicipioCommandHandler :
    IRequestHandler<RelatorioEpidemiologicoPorMunicipioCommand, Result<RelatorioEpidemiologicoPorMunicipioCommandResult>>
{
    private readonly IMapper _mapper;
    private readonly IServicoBuscaSolicitantePorCpf _servicoBuscaSolicitantePorCpf;
    private readonly IServicoCadastroSolicitante _servicoCadastroSolicitante;
    private readonly IServicoBuscaMunicipioPorNome _servicoBuscaMunicipioPorNome;
    private readonly IServicoCalculadoraSemana _servicoCalculadoraSemana;
    private readonly IServicoRelatorioAlerta _servicoRelatorioAlerta;
    private readonly IServicoCadastroRelatorio _servicoCadastroRelatorio;

    public RelatorioEpidemiologicoPorMunicipioCommandHandler(
        IMapper mapper,
        IServicoBuscaSolicitantePorCpf servicoBuscaSolicitantePorCpf,
        IServicoCadastroSolicitante servicoCadastroSolicitante,
        IServicoBuscaMunicipioPorNome servicoBuscaMunicipioPorNome,
        IServicoCalculadoraSemana servicoCalculadoraSemana,
        IServicoRelatorioAlerta servicoRelatorioAlerta,
        IServicoCadastroRelatorio servicoCadastroRelatorio)
    {
        _mapper = mapper;
        _servicoBuscaSolicitantePorCpf = servicoBuscaSolicitantePorCpf;
        _servicoCadastroSolicitante = servicoCadastroSolicitante;
        _servicoBuscaMunicipioPorNome = servicoBuscaMunicipioPorNome;
        _servicoCalculadoraSemana = servicoCalculadoraSemana;
        _servicoRelatorioAlerta = servicoRelatorioAlerta;
        _servicoCadastroRelatorio = servicoCadastroRelatorio;
    }

    public async Task<Result<RelatorioEpidemiologicoPorMunicipioCommandResult>> Handle(RelatorioEpidemiologicoPorMunicipioCommand command, CancellationToken cancellationToken)
    {
        Result<RelatorioEpidemiologicoPorMunicipioCommandResult> result = new();

        if (command is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorMunicipioCommand), Mensagens.ParametrosNaoInformados);

            return await Task.FromResult(result);
        }

        if (command.Solicitante is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorMunicipioCommand.Solicitante), Mensagens.SolicitanteNaoInformado);

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

            result.AddNotification(nameof(RelatorioEpidemiologicoPorMunicipioCommand.Solicitante), Mensagens.OcorreuUmErroAoCadastrarSolicitante);

            return await Task.FromResult(result);
        }

        if (string.IsNullOrWhiteSpace(command.NomeMunicipio))
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorMunicipioCommand.NomeMunicipio), Mensagens.NomeMunicipioNaoInformado);

            return await Task.FromResult(result);
        }

        var municipioEncontrado = await _servicoBuscaMunicipioPorNome.BuscarPorNomeAsync(command.NomeMunicipio, cancellationToken);

        if (municipioEncontrado is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.NaoEncontrado);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorMunicipioCommand.NomeMunicipio), Mensagens.MunicipioNaoEncontrado);

            return await Task.FromResult(result);
        }

        if (command.DataTermino < command.DataInicio)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorMunicipioCommand.DataTermino), Mensagens.DataTerminoPrecisaSerPosteriorDataInicio);

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

        result.Data = _mapper.Map<RelatorioEpidemiologicoPorMunicipioCommandResult>(relatorio);

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

    private async Task<Dominio.Entidades.Solicitante?> ValidarSolicitante(RelatorioEpidemiologicoSolicitante solicitante, Result<RelatorioEpidemiologicoPorMunicipioCommandResult> result, CancellationToken cancellationToken)
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
