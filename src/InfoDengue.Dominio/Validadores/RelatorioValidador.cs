using FluentValidation;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Dominio.Validadores;

public class RelatorioValidador : AbstractValidator<Relatorio>
{
    public RelatorioValidador()
    {
        RuleFor(x => x.DataSolicitacao)
            .NotEmpty()
                .WithMessage(Mensagens.DataSolicitacaoECampoObrigatorio);

        RuleFor(x => x.IdSolicitante)
            .NotEmpty()
                .WithMessage(Mensagens.IdSolicitanteECampoObrigatorio);

        RuleFor(x => x.IdMunicipio)
            .NotEmpty()
                .WithMessage(Mensagens.IdMunicipioECampoObrigatorio);

        RuleFor(x => x.Arbovirose)
            .NotEmpty()
                .WithMessage(Mensagens.ArboviroseECampoObrigatorio);

        RuleFor(x => x.SemanaInicio)
            .NotEmpty()
                .WithMessage(Mensagens.SemanaInicioECampoObrigatorio);

        RuleFor(x => x.SemanaTermino)
            .NotEmpty()
                .WithMessage(Mensagens.SemanaTerminoECampoObrigatorio);
    }
}