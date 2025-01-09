using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Infraestrutura.BancoDados;
using Microsoft.EntityFrameworkCore;

namespace InfoDengue.Infraestrutura.Repositorios;

public class RepositorioSolicitante : Repositorio<Solicitante>, IRepositorioSolicitante
{
    public RepositorioSolicitante(InfoDengueDbContext database) : base(database)
    {
    }

    public async Task<Solicitante?> BuscarPorCpfAsync(string cpf)
    {
        return await _dbSet.FirstOrDefaultAsync(entity => entity.Cpf == cpf);
    }
}