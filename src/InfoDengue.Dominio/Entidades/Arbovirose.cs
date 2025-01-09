namespace InfoDengue.Dominio.Entidades;

public class Arbovirose : Entidade
{
    public Arbovirose(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; private set; }

    #region Constantes
    public const int NOME_MAXIMO_CARACTERES = 255;
    #endregion
}