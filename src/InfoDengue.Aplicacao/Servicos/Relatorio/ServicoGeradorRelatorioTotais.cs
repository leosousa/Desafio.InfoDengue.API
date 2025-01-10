using AutoMapper;
using InfoDengue.Aplicacao.Contratos;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Aplicacao.Servicos.Relatorio;

public class ServicoGeradorRelatorioTotais : IServicoGeradorRelatorioTotais
{
    private readonly IMapper _mapper;
    private readonly IServicoGeradorRelatorioEpidemiologico _servicoGeradorRelatorioEpidemiologico;

    public ServicoGeradorRelatorioTotais(IMapper mapper, IServicoGeradorRelatorioEpidemiologico servicoGeradorRelatorioEpidemiologico)
    {
        _mapper = mapper;
        _servicoGeradorRelatorioEpidemiologico = servicoGeradorRelatorioEpidemiologico;
    }

    public async Task<Result<RelatorioEpidemiologicoTotalCommandResult>> GerarRelatorioEpidemiologicoTotais(RelatorioEpidemiologicoTotalCommand command, CancellationToken cancellationToken)
    {
        var parametros = _mapper.Map<RelatorioEpidemiologicoCommand>(command);

        var resultRelatorioGerado = await _servicoGeradorRelatorioEpidemiologico.GerarRelatorioEpidemiologico(parametros, cancellationToken);

        Result<RelatorioEpidemiologicoTotalCommandResult> result = new();

        if (!resultRelatorioGerado.Data.Any())
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.NaoEncontrado);

            result.AddNotification(nameof(RelatorioEpidemiologicoCommand), Mensagens.NenhumDadoEncontrado);

            return await Task.FromResult(result);
        }

        result.Data = new RelatorioEpidemiologicoTotalCommandResult
        {
            Arbovirose = command.Arbovirose,
            DataInicioPesquisada = command.DataInicio,
            DataTerminoPesquisada = command.DataTermino,
            TotalCasosAcumuladoPeriodo = resultRelatorioGerado.Data!.FirstOrDefault()!.NumeroCasosAcumuladoAno
        };

        result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.Sucesso);

        return await Task.FromResult(result);
    }
}