using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Infraestrutura.BancoDados;

namespace InfoDengue.Infraestrutura.Repositorios;

public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
{
    public RepositorioUsuario(InfoDengueDbContext database) : base(database)
    {
    }
}