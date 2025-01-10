namespace InfoDengue.Dominio.Contratos.Servicos.Solicitante;

public interface IServicoListagemSolicitante : IServico
{
    Task<IEnumerable<Entidades.Solicitante>> ListarAsync(CancellationToken cancellationToken);
}