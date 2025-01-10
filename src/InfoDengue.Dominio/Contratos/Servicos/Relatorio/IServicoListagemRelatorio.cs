namespace InfoDengue.Dominio.Contratos.Servicos.Relatorio;

public interface IServicoListagemRelatorio : IServico
{
    Task<IEnumerable<Entidades.Relatorio>> ListarAsync(CancellationToken cancellationToken);
}