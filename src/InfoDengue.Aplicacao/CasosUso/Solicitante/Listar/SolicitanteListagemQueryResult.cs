namespace InfoDengue.Aplicacao.CasosUso.Solicitante.Listar;

public class SolicitanteListagemQueryResult : List<SolicitanteListagemItemQueryResult>
{

}

public class SolicitanteListagemItemQueryResult
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Cpf { get; set; }
}