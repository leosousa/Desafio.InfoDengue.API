using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Contratos.Servicos.Usuario;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Dominio.Servicos.Usuario;

public class ServicoBuscaUsuarioPorId : ServicoDominio, IServicoBuscaUsuarioPorId
{
    private readonly IRepositorioUsuario _repositorioUsuario;

    public ServicoBuscaUsuarioPorId(IRepositorioUsuario repositorioUsuario)
    {
        _repositorioUsuario = repositorioUsuario;
    }

    public async Task<Entidades.Usuario?> BuscarPorIdAsync(int id, CancellationToken cancellationToken)
    {
        if (id <= 0)
        {
            AddNotification(nameof(id), Mensagens.CodigoUsuarioInvalido);

            return await Task.FromResult<Entidades.Usuario?>(null);
        }

        var usuarioEncontrado = await _repositorioUsuario.BuscarPorIdAsync(id);

        if (usuarioEncontrado is null)
        {
            return await Task.FromResult<Entidades.Usuario?>(null);
        }

        return await Task.FromResult(usuarioEncontrado);
    }
}