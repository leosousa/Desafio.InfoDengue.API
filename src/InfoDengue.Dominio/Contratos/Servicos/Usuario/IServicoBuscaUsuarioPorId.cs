namespace InfoDengue.Dominio.Contratos.Servicos.Usuario;

public interface IServicoBuscaUsuarioPorId : IServico
{
    Task<Entidades.Usuario?> BuscarPorIdAsync(int id, CancellationToken cancellationToken);
}