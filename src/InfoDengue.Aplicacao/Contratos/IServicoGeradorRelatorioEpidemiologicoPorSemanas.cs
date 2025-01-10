using InfoDengue.Aplicacao.DTOs;

namespace InfoDengue.Aplicacao.Contratos;

public interface IServicoGeradorRelatorioEpidemiologicoPorSemanas 
{
    Task<Result<RelatorioEpidemiologicoSemanasCommandResult>> GerarRelatorioEpidemiologico(RelatorioEpidemiologicoSemanasCommand parametros, CancellationToken cancellationToken);
}