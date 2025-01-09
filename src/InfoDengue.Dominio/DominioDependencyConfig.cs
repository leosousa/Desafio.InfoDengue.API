using FluentValidation;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;
using InfoDengue.Dominio.Servicos.Solicitante;
using InfoDengue.Dominio.Validadores;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;

public static class DominioDependencyConfig
{
    public static void AdicionarDependenciasDominio(this IServiceCollection services)
    {
        services.AddScoped<IServicoCadastroSolicitante, ServicoCadastroSolicitante>();
        services.AddScoped<IServicoBuscaSolicitantePorId, ServicoBuscaSolicitantePorId>();
        services.AddScoped<IServicoBuscaSolicitantePorCpf, ServicoBuscaSolicitantePorCpf>();

        services.AddValidatorsFromAssemblyContaining<SolicitanteValidador>();
    }
}