using InfoDengue.Aplicacao.DTOs;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorMunicipio.BuscarRelatorioPorMunicipio;

public class RelatorioEpidemiologicoPorMunicipioCommand : IRequest<Result<RelatorioEpidemiologicoCommandResult>>
{
    public RelatorioEpidemiologicoCommandResultSolicitante Solicitante { get; set; }

    public string NomeMunicipio { get; set; }

    public string Arbovirose { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataTermino { get; set; }
}

public class RelatorioEpidemiologicoCommandResultSolicitante
{
    public string Nome { get; set; }

    public string Cpf { get; set; }
}