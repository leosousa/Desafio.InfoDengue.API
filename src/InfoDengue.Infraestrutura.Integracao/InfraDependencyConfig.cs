using InfoDengue.Infraestrutura.Integracao.Contratos;
using InfoDengue.Infraestrutura.Integracao.Servicos;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfraDependencyConfig
{
    public static void AdicionarDependenciasServicoExterno(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IServicoRelatorioAlerta, ServicoRelatorioAlerta>();
    }
}