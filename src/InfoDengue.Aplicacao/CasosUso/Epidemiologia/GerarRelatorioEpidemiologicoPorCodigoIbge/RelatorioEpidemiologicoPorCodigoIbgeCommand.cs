using InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorMunicipio.BuscarRelatorioPorMunicipio;
using InfoDengue.Aplicacao.DTOs;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorCodigoIbge;

public class RelatorioEpidemiologicoPorCodigoIbgeCommand : IRequest<Result<RelatorioEpidemiologicoPorCodigoIbgeCommandResult>>
{
    public RelatorioEpidemiologicoPorCodigoSolicitante Solicitante { get; set; }

    public int CodigoIbge { get; set; }

    public string Arbovirose { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataTermino { get; set; }
}

public class RelatorioEpidemiologicoPorCodigoSolicitante
{
    public string Nome { get; set; }

    public string Cpf { get; set; }
}