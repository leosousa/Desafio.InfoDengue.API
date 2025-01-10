using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Infraestrutura.BancoDados;

namespace InfoDengue.Infraestrutura.Repositorios;

public class RepositorioRelatorio : Repositorio<Relatorio>, IRepositorioRelatorio
{
    public RepositorioRelatorio(InfoDengueDbContext database) : base(database)
    {
    }
}