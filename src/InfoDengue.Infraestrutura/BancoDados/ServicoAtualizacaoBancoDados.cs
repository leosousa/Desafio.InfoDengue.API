using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InfoDengue.Infraestrutura.BancoDados;

public static class ServicoAtualizacaoBancoDados
{
    public static void UseServicoAtualizacaoBancoDados(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            serviceScope.ServiceProvider.GetService<InfoDengueDbContext>()?.Database.Migrate();
        }
    }
}