namespace InfoDengue.Infraestrutura.Integracao.DTOs;

public class RelatorioAlertaItem
{
    /// <summary>
    /// Primeiro dia da semana epidemiológica (Domingo)
    /// </summary>
    public long data_iniSE { get; set; }

    /// <summary>
    /// Semana epidemiológica
    /// </summary>
    public int SE { get; set; }

    /// <summary>
    /// Número estimado de casos por semana usando o modelo de nowcasting
    /// </summary>
    /// <remarks>Os valores são atualizados retrospectivamente a cada semana</remarks>
    public double casos_est { get; set; }

    /// <summary>
    /// Intervalo mínimo de credibilidade de 95% do número estimado de casos
    /// </summary>
    public double casos_est_min { get; set; }

    /// <summary>
    /// Intervalo máximo de credibilidade de 95% do número estimado de casos
    /// </summary>
    public double? casos_est_max { get; set; }

    /// <summary>
    /// Número de casos notificados por semana
    /// </summary>
    /// <remarks>Os valores são atualizados retrospectivamente todas as semanas</remarks>
    public int casos { get; set; }

    /// <summary>
    /// Probabilidade de (Rt> 1). Para emitir o alerta laranja, usamos o critério p_rt1> 0,95 por 3 semanas ou mais
    /// </summary>
    public double p_rt1 { get; set; }

    /// <summary>
    /// Taxa de incidência estimada por 100.000
    /// </summary>
    public double p_inc100k { get; set; }

    /// <summary>
    /// Divisão submunicipal
    /// </summary>
    /// <remarks>Atualmente implementada apenas no Rio de Janeiro</remarks>
    public int Localidade_id { get; set; }

    /// <summary>
    /// Nível de alerta (1 = verde, 2 = amarelo, 3 = laranja, 4 = vermelho)
    /// </summary>
    public int nivel { get; set; }

    /// <summary>
    /// Índice numérico
    /// </summary>
    public long id { get; set; }

    /// <summary>
    /// Versão do modelo (uso interno)
    /// </summary>
    public string versao_modelo { get; set; }


    public double? tweet { get; set; }

    /// <summary>
    /// Estimativa pontual do número reprodutivo de casos
    /// </summary>
    /// <remarks>https://info.dengue.mat.br/informacoes/</remarks>
    public double Rt { get; set; }

    /// <summary>
    /// População estimada (IBGE)
    /// </summary>
    public double pop { get; set; }

    /// <summary>
    /// Média das temperaturas mínimas diárias ao longo da semana
    /// </summary>
    public double tempmin { get; set; }

    /// <summary>
    /// Média da umidade relativa máxima diária do ar ao longo da semana
    /// </summary>
    public double? umidmax { get; set; }

    /// <summary>
    /// Indica receptividade climática, ou seja, condições para alta capacidade vetorial. 
    /// 0 = desfavorável, 1 = favorável, 2 = favorável nesta semana e na semana passada, 
    /// 3 = favorável por pelo menos três semanas (suficiente para completar um ciclo de transmissão)
    /// </summary>
    public int receptivo { get; set; }

    /// <summary>
    /// Evidência de transmissão sustentada: 0 = nenhuma evidência, 1 = possível, 2 = provável, 
    /// 3 = altamente provável
    /// </summary>
    public int transmissao { get; set; }

    /// <summary>
    /// Incidência estimada abaixo do limiar pré-epidemia, 1 = acima do limiar pré-epidemia, mas abaixo 
    /// do limiar epidêmico, 2 = acima do limiar epidêmico
    /// </summary>
    public int nivel_inc { get; set; }
    public double? umidmed { get; set; }
    public double? umidmin { get; set; }
    public double? tempmed { get; set; }
    public double? tempmax { get; set; }
    public double? casprov { get; set; }
    public object casprov_est { get; set; }
    public object casprov_est_min { get; set; }
    public object casprov_est_max { get; set; }
    public object casconf { get; set; }

    /// <summary>
    /// Número acumulado de casos no ano
    /// </summary>
    public int notif_accum_year { get; set; }
}