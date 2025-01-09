using InfoDengue.Dominio.Entidades;

namespace InfoDengue.Dominio.Recursos;

public class Mensagens
{
    public const string NomeECampoObrigatorio = "Nome é campo obrigatório";
    public static string NomePodeTerAteXCaracteres = $"Nome precisa ter no máximo {Solicitante.NOME_MAXIMO_CARACTERES.ToString()} caracteres";
    public const string CpfECampoObrigatorio = "Cpf é campo obrigatório";
    public static string CpfPodeTerAteXCaracteres = $"Nome precisa ter no máximo {Solicitante.CPF_MAXIMO_CARACTERES.ToString()} caracteres";
    public const string CpfInvalido = "Cpf inválido";
    public const string SolicitanteNaoInformado = "Solicitante não informado";
    public const string OcorreuUmErroAoCadastrarSolicitante = "Ocorreu um erro ao cadastrar o soliitante. Por favor, tente novamente";
    public const string CodigoSolicitanteInvalido = "Código do solicitante inválido";
    public const string CodigoSolicitanteNaoInformado = "Código do solicitante não informado";
    public const string CpfNaoInformado = "Cpf não informado";
    public const string SolicitanteNaoEncontrado = "Solicitante não encontrado";
    public const string SolicitanteJaCadastrado = "Solicitante já cadastrado";
}