using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Contratos.Servicos.Usuario;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Dominio.Servicos.Usuario;

public class ServicoBuscaUsuarioPorCpf : ServicoDominio, IServicoBuscaUsuarioPorCpf
{
    private readonly IRepositorioUsuario _repositorioUsuario;

    public ServicoBuscaUsuarioPorCpf(IRepositorioUsuario repositorioUsuario)
    {
        _repositorioUsuario = repositorioUsuario;
    }

    public async Task<Entidades.Usuario?> BuscarPorCpfAsync(string cpf, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(cpf))
        {
            AddNotification(nameof(cpf), Mensagens.CpfInvalido);

            return await Task.FromResult<Entidades.Usuario?>(null);
        }

        var usuarioEncontrado = await _repositorioUsuario.BuscarPorCpfAsync(cpf);

        if (usuarioEncontrado is null)
        {
            return await Task.FromResult<Entidades.Usuario?>(null);
        }

        return await Task.FromResult(usuarioEncontrado);
    }
}