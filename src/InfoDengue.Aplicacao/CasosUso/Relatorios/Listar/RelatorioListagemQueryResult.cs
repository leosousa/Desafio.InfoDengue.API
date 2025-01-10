namespace InfoDengue.Aplicacao.CasosUso.Relatorios.Listar;

public class RelatorioListagemQueryResult : List<RelatorioListagemItemQueryResult>
{
}


public class RelatorioListagemItemQueryResult
{
    public int Id { get; set; }

    public DateTime DataSolicitacao { get; set; }

    public int SemanaInicio { get; set; }

    public int SemanaTermino { get; set; }

    public int CodigoIbge { get; set; }

    public string Municipio { get; set; }

    public string Arbovirose { get; set; }

    public string Solicitante { get; set; }
}