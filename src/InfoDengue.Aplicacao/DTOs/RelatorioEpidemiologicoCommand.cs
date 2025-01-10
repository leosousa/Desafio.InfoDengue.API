using MediatR;

namespace InfoDengue.Aplicacao.DTOs;

public class RelatorioEpidemiologicoCommand : IRequest<Result<RelatorioEpidemiologicoCommandResult>>
{
    public RelatorioEpidemiologicoSolicitanteCommand Solicitante { get; set; }

    public int CodigoIbge { get; set; }

    public string Arbovirose { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataTermino { get; set; }
}

public class RelatorioEpidemiologicoSolicitanteCommand
{
    public string Nome { get; set; }

    public string Cpf { get; set; }
}