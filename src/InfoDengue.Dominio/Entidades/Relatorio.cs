namespace InfoDengue.Dominio.Entidades;

public class Relatorio : Entidade
{
    public Relatorio(DateTime dataSolicitacao, 
        int idArbovirose, 
        int semanaInicio, 
        int semanaTermino, 
        int idMunicipio, 
        int idSolicitante)
    {
        DataSolicitacao = dataSolicitacao;
        IdArbovirose = idArbovirose;
        SemanaInicio = semanaInicio;
        SemanaTermino = semanaTermino;
        IdMunicipio = idMunicipio;
        IdSolicitante = idSolicitante;
    }

    public DateTime DataSolicitacao { get; private set; }

    public int SemanaInicio { get; private set; }

    public int SemanaTermino { get; private set; }

    public int IdArbovirose { get; private set; }

    public Arbovirose Arbovirose { get; private set; }

    public int IdMunicipio { get; private set; }

    public Municipio Municipio { get; private set; }

    public int IdSolicitante { get; private set; }

    public Solicitante Solicitante { get; private set; }
}