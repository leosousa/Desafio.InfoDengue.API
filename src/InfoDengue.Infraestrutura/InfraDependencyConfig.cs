using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Infraestrutura.BancoDados;
using InfoDengue.Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfraDependencyConfig
{
    public static void AdicionarDependenciasInfraestrutura(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InfoDengueDbContext>(db =>
            db.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
            ServiceLifetime.Singleton
        );

        services.AddScoped<IRepositorioSolicitante, RepositorioSolicitante>();
        services.AddScoped<IRepositorioMunicipio, RepositorioMunicipio>();
        services.AddScoped<IRepositorioRelatorio, RepositorioRelatorio>();
    }
}