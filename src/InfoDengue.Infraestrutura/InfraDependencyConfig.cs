using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Infraestrutura.BancoDados;
using InfoDengue.Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfoDengue.Infraestrutura;

public static class InfraDependencyConfig
{
    public static void AdicionarDependenciasInfraestrutura(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InfoDengueDbContext>(db =>
            db.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
            ServiceLifetime.Singleton
        );

        services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
    }
}