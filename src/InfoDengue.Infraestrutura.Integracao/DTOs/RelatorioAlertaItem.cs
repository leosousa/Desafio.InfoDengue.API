namespace InfoDengue.Infraestrutura.Integracao.DTOs;

public class RelatorioAlertaItem
{
    public long data_iniSE { get; set; }
    public int SE { get; set; }
    public double casos_est { get; set; }
    public int casos_est_min { get; set; }
    public double? casos_est_max { get; set; }
    public int casos { get; set; }
    public double p_rt1 { get; set; }
    public double p_inc100k { get; set; }
    public int Localidade_id { get; set; }
    public int nivel { get; set; }
    public long id { get; set; }
    public string versao_modelo { get; set; }
    public double? tweet { get; set; }
    public double Rt { get; set; }
    public double pop { get; set; }
    public double tempmin { get; set; }
    public double? umidmax { get; set; }
    public int receptivo { get; set; }
    public int transmissao { get; set; }
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
    public int notif_accum_year { get; set; }
}