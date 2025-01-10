using InfoDengue.Aplicacao.DTOs;

namespace InfoDengue.Aplicacao.Contratos;

public interface IServicoGeradorRelatorioEpidemiologico
{
    Task<Result<RelatorioEpidemiologicoCommandResult>> GerarRelatorioEpidemiologico(RelatorioEpidemiologicoCommand parametros, CancellationToken cancellationToken);
}