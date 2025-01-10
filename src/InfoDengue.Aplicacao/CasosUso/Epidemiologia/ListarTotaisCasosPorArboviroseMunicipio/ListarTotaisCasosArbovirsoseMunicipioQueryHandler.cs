using AutoMapper;
using InfoDengue.Aplicacao.CasosUso.Solicitante.BuscarPorCpf;
using InfoDengue.Aplicacao.Contratos;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Dominio.Contratos.Servicos.Municipio;
using InfoDengue.Dominio.Recursos;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Epidemiologia.ListarTotaisCasosPorArboviroseMunicipio;

public class ListarTotaisCasosArbovirsoseMunicipioQueryHandler :
    IRequestHandler<RelatorioEpidemiologicoTotalCommand, Result<RelatorioEpidemiologicoTotalCommandResult>>
{
    private readonly IMapper _mapper;
    private readonly IServicoGeradorRelatorioEpidemiologico _servicoGeradorRelatorioEpidemiologico;

    public ListarTotaisCasosArbovirsoseMunicipioQueryHandler(IMapper mapper, IServicoGeradorRelatorioEpidemiologico servicoGeradorRelatorioEpidemiologico)
    {
        _mapper = mapper;
        _servicoGeradorRelatorioEpidemiologico = servicoGeradorRelatorioEpidemiologico;
    }

    public async Task<Result<RelatorioEpidemiologicoTotalCommandResult>> Handle(RelatorioEpidemiologicoTotalCommand command, CancellationToken cancellationToken)
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

        return await Task.FromResult(result);
    }
}