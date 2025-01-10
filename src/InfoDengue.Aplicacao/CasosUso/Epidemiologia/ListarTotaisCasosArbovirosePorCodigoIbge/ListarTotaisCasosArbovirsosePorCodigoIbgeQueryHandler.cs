using InfoDengue.Aplicacao.Contratos;
using InfoDengue.Aplicacao.DTOs;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Epidemiologia.ListarTotaisCasosArbovirosePorCodigoIbge;

public class ListarTotaisCasosArbovirsosePorCodigoIbgeQueryHandler :
    IRequestHandler<RelatorioEpidemiologicoTotalCommand, Result<RelatorioEpidemiologicoTotalCommandResult>>
{
    private readonly IServicoGeradorRelatorioTotais _servicoGeradorRelatorioTotais;

    public ListarTotaisCasosArbovirsosePorCodigoIbgeQueryHandler(IServicoGeradorRelatorioTotais servicoGeradorRelatorioTotais)
    {
        _servicoGeradorRelatorioTotais = servicoGeradorRelatorioTotais;
    }

    public async Task<Result<RelatorioEpidemiologicoTotalCommandResult>> Handle(RelatorioEpidemiologicoTotalCommand command, CancellationToken cancellationToken)
    {
        return await _servicoGeradorRelatorioTotais.GerarRelatorioEpidemiologicoTotais(command, cancellationToken).ConfigureAwait(false);
    }
}