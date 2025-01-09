namespace InfoDengue.Dominio.Validadores;

public class ValidadorCpf
{
    public static bool Validar(string cpf)
    {
        if (string.IsNullOrEmpty(cpf)) return false;

        // Remove caracteres não numéricos
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11) return false;

        // Verifica se todos os dígitos são iguais
        if (cpf.Distinct().Count() == 1) return false;

        // Cálculo dos dígitos verificadores
        int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int soma = tempCpf
            .Select((t, i) => int.Parse(t.ToString()) * multiplicadores1[i])
            .Sum();

        int resto = soma % 11;
        string digito = (resto < 2 ? 0 : 11 - resto).ToString();

        tempCpf += digito;

        soma = tempCpf
            .Select((t, i) => int.Parse(t.ToString()) * multiplicadores2[i])
            .Sum();

        resto = soma % 11;
        digito += (resto < 2 ? 0 : 11 - resto).ToString();

        return cpf.EndsWith(digito);
    }
}