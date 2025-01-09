namespace InfoDengue.Dominio.Contratos.Servicos.Solicitante;

public interface IServicoCadastroSolicitante : IServico
{
    Task<Entidades.Solicitante?> CadastrarAsync(Entidades.Solicitante livro, CancellationToken cancellationToken);
}