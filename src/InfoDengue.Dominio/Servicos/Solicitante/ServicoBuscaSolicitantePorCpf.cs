using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Dominio.Servicos.Solicitante;

public class ServicoBuscaSolicitantePorCpf : ServicoDominio, IServicoBuscaSolicitantePorCpf
{
    private readonly IRepositorioSolicitante _repositorioUsuario;

    public ServicoBuscaSolicitantePorCpf(IRepositorioSolicitante repositorioUsuario)
    {
        _repositorioUsuario = repositorioUsuario;
    }

    public async Task<Entidades.Solicitante?> BuscarPorCpfAsync(string cpf, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(cpf))
        {
            AddNotification(nameof(cpf), Mensagens.CpfInvalido);

            return await Task.FromResult<Entidades.Solicitante?>(null);
        }

        var usuarioEncontrado = await _repositorioUsuario.BuscarPorCpfAsync(cpf);

        if (usuarioEncontrado is null)
        {
            return await Task.FromResult<Entidades.Solicitante?>(null);
        }

        return await Task.FromResult(usuarioEncontrado);
    }
}