using MediatR;

namespace InfoDengue.Aplicacao.DTOs;

public class RelatorioEpidemiologicoTotalCommand : IRequest<Result<RelatorioEpidemiologicoTotalCommandResult>>
{
    public SolicitanteDto Solicitante { get; set; }

    public int CodigoIbge { get; set; }

    public string Arbovirose { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataTermino { get; set; }
}