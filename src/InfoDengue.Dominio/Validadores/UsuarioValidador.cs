using FluentValidation;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Dominio.Validadores;

public class UsuarioValidador : AbstractValidator<Usuario>
{
    public UsuarioValidador()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
                .WithMessage(Mensagens.NomeECampoObrigatorio)
            .MaximumLength(Usuario.NOME_MAXIMO_CARACTERES)
                .WithMessage(Mensagens.NomePodeTerAteXCaracteres);

        RuleFor(x => x.Cpf)
            .NotEmpty()
                .WithMessage(Mensagens.CpfECampoObrigatorio)
            .MaximumLength(Usuario.CPF_MAXIMO_CARACTERES)
                .WithMessage(Mensagens.CpfPodeTerAteXCaracteres)
            .Must(ValidadorCpf.Validar)
                .WithMessage(Mensagens.CpfInvalido);
    }
}