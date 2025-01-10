namespace InfoDengue.Infraestrutura.Integracao.Helpers;

/// <summary>
/// Serviço para calcular semana do ano a partir de uma data
/// </summary>
public interface IServicoCalculadoraSemana
{
    /// <summary>
    /// Calcula o número da semana do ano a partir de uma data
    /// </summary>
    /// <param name="data">Data de referência</param>
    /// <returns>Número da semana relacionada à data</returns>
    Task<int> CalcularSemana(DateTime data);
}