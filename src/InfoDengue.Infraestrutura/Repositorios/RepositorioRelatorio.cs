using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Infraestrutura.BancoDados;
using Microsoft.EntityFrameworkCore;

namespace InfoDengue.Infraestrutura.Repositorios;

public class RepositorioRelatorio : Repositorio<Relatorio>, IRepositorioRelatorio
{
    public RepositorioRelatorio(InfoDengueDbContext database) : base(database)
    {
    }

    public async Task<IEnumerable<Relatorio>> ListarAsync()
    {
        return await _dbSet.ToListAsync();
    }
}