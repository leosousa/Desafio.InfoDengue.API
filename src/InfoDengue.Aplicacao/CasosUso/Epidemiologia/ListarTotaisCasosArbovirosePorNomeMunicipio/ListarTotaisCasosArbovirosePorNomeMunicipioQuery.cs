using InfoDengue.Aplicacao.DTOs;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Epidemiologia.ListarTotaisCasosArbovirosePorNomeMunicipio;

public class ListarTotaisCasosArbovirosePorNomeMunicipioQuery : IRequest<Result<RelatorioEpidemiologicoTotalCommandResult>>
{
    public SolicitanteDto Solicitante { get; set; }

    public string NomeMunicipio { get; set; }

    public string Arbovirose { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataTermino { get; set; }
}