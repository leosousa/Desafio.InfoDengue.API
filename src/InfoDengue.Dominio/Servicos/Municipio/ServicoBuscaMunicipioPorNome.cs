using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Contratos.Servicos.Municipio;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Dominio.Servicos.Municipio;

public class ServicoBuscaMunicipioPorNome : ServicoDominio, IServicoBuscaMunicipioPorNome
{
    private readonly IRepositorioMunicipio _repositorioMunicipio;

    public ServicoBuscaMunicipioPorNome(IRepositorioMunicipio repositorioMunicipio)
    {
        this._repositorioMunicipio = repositorioMunicipio;
    }

    public async Task<Entidades.Municipio?> BuscarPorNomeAsync(string nome, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            AddNotification(nameof(nome), Mensagens.NomeMunicipioNaoInformado);

            return await Task.FromResult<Entidades.Municipio?>(null);
        }

        var municipioEncontrado = await _repositorioMunicipio.BuscarPorNomeAsync(nome);

        if (municipioEncontrado is null)
        {
            return await Task.FromResult<Entidades.Municipio?>(null);
        }

        return await Task.FromResult(municipioEncontrado);
    }
}