using InfoDengue.Dominio.Entidades;

namespace InfoDengue.Dominio.Recursos;

public class Mensagens
{
    public const string NomeECampoObrigatorio = "Nome é campo obrigatório";
    public static string NomePodeTerAteXCaracteres = $"Nome precisa ter no máximo {Usuario.NOME_MAXIMO_CARACTERES.ToString()} caracteres";
    public const string CpfECampoObrigatorio = "Cpf é campo obrigatório";
    public static string CpfPodeTerAteXCaracteres = $"Nome precisa ter no máximo {Usuario.CPF_MAXIMO_CARACTERES.ToString()} caracteres";
    public const string CpfInvalido = "Cpf é inválido";
}