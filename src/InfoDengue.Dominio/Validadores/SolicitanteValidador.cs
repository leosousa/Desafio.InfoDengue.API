using FluentValidation;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Dominio.Validadores;

public class SolicitanteValidador : AbstractValidator<Solicitante>
{
    public SolicitanteValidador()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
                .WithMessage(Mensagens.NomeECampoObrigatorio)
            .MaximumLength(Solicitante.NOME_MAXIMO_CARACTERES)
                .WithMessage(Mensagens.NomePodeTerAteXCaracteres);

        RuleFor(x => x.Cpf)
            .NotEmpty()
                .WithMessage(Mensagens.CpfECampoObrigatorio)
            .MaximumLength(Solicitante.CPF_MAXIMO_CARACTERES)
                .WithMessage(Mensagens.CpfPodeTerAteXCaracteres)
            .Must(ValidadorCpf.Validar)
                .WithMessage(Mensagens.CpfInvalido);
    }
}