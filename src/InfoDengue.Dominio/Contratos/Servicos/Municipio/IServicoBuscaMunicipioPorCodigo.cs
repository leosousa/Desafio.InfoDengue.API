namespace InfoDengue.Dominio.Contratos.Servicos.Municipio;

public interface IServicoBuscaMunicipioPorCodigo : IServico
{
    Task<Entidades.Municipio?> BuscarPorCodigoAsync(int codigo, CancellationToken cancellationToken);
}