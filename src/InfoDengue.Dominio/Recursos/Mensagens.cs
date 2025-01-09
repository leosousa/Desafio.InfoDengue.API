using InfoDengue.Dominio.Entidades;

namespace InfoDengue.Dominio.Recursos;

public class Mensagens
{
    public const string NomeECampoObrigatorio = "Nome é campo obrigatório";
    public static string NomePodeTerAteXCaracteres = $"Nome precisa ter no máximo {Usuario.NOME_MAXIMO_CARACTERES.ToString()} caracteres";
    public const string CpfECampoObrigatorio = "Cpf é campo obrigatório";
    public static string CpfPodeTerAteXCaracteres = $"Nome precisa ter no máximo {Usuario.CPF_MAXIMO_CARACTERES.ToString()} caracteres";
    public const string CpfInvalido = "Cpf inválido";
    public const string UsuarioNaoInformado = "Usuário não informado";
    public const string OcorreuUmErroAoCadastrarUsuario = "Ocorreu um erro ao cadastrar o usuário. Por favor, tente novamente";
    public const string CodigoUsuarioInvalido = "Código do usuário inválido";
    public const string CodigoUsuarioNaoInformado = "Código do usuário não informado";
    public const string CpfNaoInformado = "Cpf não informado";
    public const string UsuarioNaoEncontrado = "Usuário não encontrado";
    public const string UsuarioJaCadastrado = "Usuário já cadastrado";
}