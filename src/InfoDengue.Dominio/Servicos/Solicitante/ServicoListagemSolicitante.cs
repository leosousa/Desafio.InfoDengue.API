using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;

namespace InfoDengue.Dominio.Servicos.Solicitante;

public class ServicoListagemSolicitante : ServicoDominio, IServicoListagemSolicitante
{
    private readonly IRepositorioSolicitante _repositorio;

    public ServicoListagemSolicitante(
        IRepositorioSolicitante repositorio)
    {
        _repositorio = repositorio;
    }
    public async Task<IEnumerable<Entidades.Solicitante?>> ListarAsync(CancellationToken cancellationToken)
    {
        return await _repositorio.ListarAsync();
    }
}