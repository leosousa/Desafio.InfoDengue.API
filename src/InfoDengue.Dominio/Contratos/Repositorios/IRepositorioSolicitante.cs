using InfoDengue.Dominio.Entidades;

namespace InfoDengue.Dominio.Contratos.Repositorios;

public interface IRepositorioSolicitante : IRepositorio<Solicitante>
{
    Task<Solicitante?> BuscarPorCpfAsync(string cpf);

    Task<IEnumerable<Solicitante>> ListarAsync();
}