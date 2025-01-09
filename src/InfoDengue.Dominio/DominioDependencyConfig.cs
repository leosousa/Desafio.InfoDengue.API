using FluentValidation;
using InfoDengue.Dominio.Contratos.Servicos.Usuario;
using InfoDengue.Dominio.Servicos.Usuario;
using InfoDengue.Dominio.Validadores;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;

public static class DominioDependencyConfig
{
    public static void AdicionarDependenciasDominio(this IServiceCollection services)
    {
        services.AddScoped<IServicoCadastroUsuario, ServicoCadastroUsuario>();
        services.AddScoped<IServicoBuscaUsuarioPorId, ServicoBuscaUsuarioPorId>();
        services.AddScoped<IServicoBuscaUsuarioPorCpf, ServicoBuscaUsuarioPorCpf>();

        services.AddValidatorsFromAssemblyContaining<UsuarioValidador>();
    }
}