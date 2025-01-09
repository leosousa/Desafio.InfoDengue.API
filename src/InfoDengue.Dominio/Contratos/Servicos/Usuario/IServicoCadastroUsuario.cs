namespace InfoDengue.Dominio.Contratos.Servicos.Usuario;

public interface IServicoCadastroUsuario : IServico
{
    Task<Entidades.Usuario?> CadastrarAsync(Entidades.Usuario livro, CancellationToken cancellationToken);
}