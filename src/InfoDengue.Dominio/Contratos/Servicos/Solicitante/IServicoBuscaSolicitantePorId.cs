namespace InfoDengue.Dominio.Contratos.Servicos.Solicitante;

public interface IServicoBuscaSolicitantePorId : IServico
{
    Task<Entidades.Solicitante?> BuscarPorIdAsync(int id, CancellationToken cancellationToken);
}