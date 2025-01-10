using InfoDengue.Aplicacao.DTOs;

namespace InfoDengue.Aplicacao.Contratos;

public interface IServicoGeradorRelatorioTotais
{
    Task<Result<RelatorioEpidemiologicoTotalCommandResult>> GerarRelatorioEpidemiologicoTotais(RelatorioEpidemiologicoTotalCommand parametros, CancellationToken cancellationToken);
}