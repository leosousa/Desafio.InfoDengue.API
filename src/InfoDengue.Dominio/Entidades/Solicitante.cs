namespace InfoDengue.Dominio.Entidades;

/// <summary>
/// Usuário que acessa a API
/// </summary>
public class Solicitante : Entidade
{
    /// <summary>
    /// Nome do solicitante
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// Documento do solicitante
    /// </summary>
    public string Cpf { get; set; }


    #region Constantes

    public const int NOME_MAXIMO_CARACTERES = 255;
    public const int CPF_MAXIMO_CARACTERES = 11;

    #endregion
}
