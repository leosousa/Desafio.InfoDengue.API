namespace InfoDengue.Aplicacao.DTOs;

public class RelatorioEpidemiologicoTotalCommandResult
{
    public DateTime DataInicioPesquisada { get; set; }

    public DateTime DataTerminoPesquisada { get; set; }

    public string Arbovirose { get; set; }

    public int TotalCasosAcumuladoPeriodo { get; set; }
}