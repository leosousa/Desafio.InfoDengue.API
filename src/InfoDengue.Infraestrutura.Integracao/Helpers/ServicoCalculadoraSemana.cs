namespace InfoDengue.Infraestrutura.Integracao.Helpers;

public class ServicoCalculadoraSemana : IServicoCalculadoraSemana
{
    /// <summary>
    /// Calcula o número da semana do ano a partir de uma data
    /// </summary>
    /// <param name="data">Data de referência</param>
    /// <returns>Número da semana relacionada à data</returns>
    public async Task<int> CalcularSemana(DateTime data)
    {
        DateTime inicioAno = new DateTime(data.Year, 1, 1);

        // Calcular o número do dia no ano
        int diaDoAno = (data - inicioAno).Days + 1;

        // Dividir por 7 para obter a semana e ajustar para base 1
        int semana = (diaDoAno - 1) / 7 + 1;

        // Garantir que a semana não ultrapasse 53
        return await Task.FromResult(Math.Min(semana, 53));
    }
}