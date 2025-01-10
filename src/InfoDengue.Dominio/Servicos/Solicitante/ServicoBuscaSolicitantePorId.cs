using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Dominio.Servicos.Solicitante;

public class ServicoBuscaSolicitantePorId : ServicoDominio, IServicoBuscaSolicitantePorId
{
    private readonly IRepositorioSolicitante _repositorioUsuario;

    public ServicoBuscaSolicitantePorId(IRepositorioSolicitante repositorioUsuario)
    {
        _repositorioUsuario = repositorioUsuario;
    }

    public async Task<Entidades.Solicitante?> BuscarPorIdAsync(int id, CancellationToken cancellationToken)
    {
        if (id <= 0)
        {
            AddNotification(nameof(id), Mensagens.CodigoSolicitanteInvalido);

            return await Task.FromResult<Entidades.Solicitante?>(null);
        }

        var usuarioEncontrado = await _repositorioUsuario.BuscarPorIdAsync(id);

        if (usuarioEncontrado is null)
        {
            return await Task.FromResult<Entidades.Solicitante?>(null);
        }

        return await Task.FromResult(usuarioEncontrado);
    }
}