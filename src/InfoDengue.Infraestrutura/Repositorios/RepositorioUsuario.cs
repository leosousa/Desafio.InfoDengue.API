using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Infraestrutura.BancoDados;
using Microsoft.EntityFrameworkCore;

namespace InfoDengue.Infraestrutura.Repositorios;

public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
{
    public RepositorioUsuario(InfoDengueDbContext database) : base(database)
    {
    }

    public async Task<Usuario?> BuscarPorCpfAsync(string cpf)
    {
        return await _dbSet.FirstOrDefaultAsync(entity => entity.Cpf == cpf);
    }
}