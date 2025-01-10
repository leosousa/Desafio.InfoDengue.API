namespace InfoDengue.Dominio.Contratos.Servicos.Relatorio;

public interface IServicoCadastroRelatorio : IServico
{
    Task<Entidades.Relatorio?> CadastrarAsync(Entidades.Relatorio relatorio, CancellationToken cancellationToken);
}