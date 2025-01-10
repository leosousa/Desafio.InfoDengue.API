using InfoDengue.Infraestrutura.Integracao.DTOs;

namespace InfoDengue.Infraestrutura.Integracao.Contratos;

public interface IServicoRelatorioAlerta
{
    Task<RelatorioAlerta> ObterRelatorio(int codigoIbge, string arbovirose, int semanaInicio, int semanaFim, int anoInicio, int anoFim);
}