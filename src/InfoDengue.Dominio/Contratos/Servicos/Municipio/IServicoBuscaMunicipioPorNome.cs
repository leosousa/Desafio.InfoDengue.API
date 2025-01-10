namespace InfoDengue.Dominio.Contratos.Servicos.Municipio;

public interface IServicoBuscaMunicipioPorNome : IServico
{
    Task<Entidades.Municipio?> BuscarPorNomeAsync(string nome, CancellationToken cancellationToken);
}