namespace InfoDengue.Dominio.Contratos.Servicos.Solicitante;

public interface IServicoBuscaSolicitantePorCpf : IServico
{
    Task<Entidades.Solicitante?> BuscarPorCpfAsync(string cpf, CancellationToken cancellationToken);
}