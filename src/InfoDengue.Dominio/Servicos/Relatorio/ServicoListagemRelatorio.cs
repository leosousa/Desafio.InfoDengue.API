using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Contratos.Servicos.Relatorio;

namespace InfoDengue.Dominio.Servicos.Relatorio;

public class ServicoListagemRelatorio : ServicoDominio, IServicoListagemRelatorio
{
    private readonly IRepositorioRelatorio _repositorio;

    public ServicoListagemRelatorio(IRepositorioRelatorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<IEnumerable<Entidades.Relatorio?>> ListarAsync(CancellationToken cancellationToken)
    {
        return await _repositorio.ListarAsync();
    }
}