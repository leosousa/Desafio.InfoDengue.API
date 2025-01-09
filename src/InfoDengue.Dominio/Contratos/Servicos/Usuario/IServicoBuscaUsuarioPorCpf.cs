namespace InfoDengue.Dominio.Contratos.Servicos.Usuario;

public interface IServicoBuscaUsuarioPorCpf : IServico
{
    Task<Entidades.Usuario?> BuscarPorCpfAsync(string cpf, CancellationToken cancellationToken);
}