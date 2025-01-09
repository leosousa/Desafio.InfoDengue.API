namespace InfoDengue.Dominio.Entidades;

public class Municipio : Entidade
{
    public Municipio(int codigoIbge, string nome)
    {
        CodigoIbge = codigoIbge;
        Nome = nome;
    }

    public int CodigoIbge { get; private set; }

    public string Nome { get; private set; }

    #region Constantes
    public const int NOME_MAXIMO_CARACTERES = 255;
    #endregion
}