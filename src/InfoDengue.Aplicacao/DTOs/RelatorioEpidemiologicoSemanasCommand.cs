using MediatR;

namespace InfoDengue.Aplicacao.DTOs;

public class RelatorioEpidemiologicoSemanasCommand : IRequest<Result<RelatorioEpidemiologicoSemanasCommandResult>>
{
    public SolicitanteDto Solicitante { get; set; }

    public int CodigoIbge { get; set; }

    public string Arbovirose { get; set; }

    public int SemanaInicio { get; set; }

    public int SemanaTermino { get; set; }

    public int AnoInicio { get; set; }

    public int AnoTermino { get; set; }
}