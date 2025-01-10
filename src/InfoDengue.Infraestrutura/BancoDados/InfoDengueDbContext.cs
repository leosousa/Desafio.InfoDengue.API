using InfoDengue.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InfoDengue.Infraestrutura.BancoDados;

public class InfoDengueDbContext : DbContext
{
    public DbSet<Solicitante> Solicitantes { get; set; }

    public DbSet<Municipio> Municipios { get; set; }

    public DbSet<Relatorio> Relatorios { get; set; }

    public InfoDengueDbContext()
    {
    }

    public InfoDengueDbContext(DbContextOptions<InfoDengueDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}