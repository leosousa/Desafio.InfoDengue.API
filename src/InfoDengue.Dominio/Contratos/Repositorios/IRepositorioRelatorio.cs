using InfoDengue.Dominio.Entidades;

namespace InfoDengue.Dominio.Contratos.Repositorios;

public interface IRepositorioRelatorio : IRepositorio<Relatorio>
{
    Task<IEnumerable<Relatorio>> ListarAsync();
}