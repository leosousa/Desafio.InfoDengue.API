using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Infraestrutura.BancoDados;
using Microsoft.EntityFrameworkCore;

namespace InfoDengue.Infraestrutura.Repositorios;

public class RepositorioMunicipio : Repositorio<Municipio>, IRepositorioMunicipio
{
    public RepositorioMunicipio(InfoDengueDbContext database) : base(database)
    {
    }

    public async Task<Municipio?> BuscarPorNomeAsync(string nome)
    {
        return await _dbSet.FirstOrDefaultAsync(entity => entity.Nome == nome);
    }

    public async Task<Municipio?> BuscarPorCodigoAsync(int codigo)
    {
        return await _dbSet.FirstOrDefaultAsync(entity => entity.CodigoIbge == codigo);
    }
}