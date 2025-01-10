using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Contratos.Servicos.Municipio;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Dominio.Servicos.Municipio;

public class ServicoBuscaMunicipioPorCodigo : ServicoDominio, IServicoBuscaMunicipioPorCodigo
{
    private readonly IRepositorioMunicipio _repositorioMunicipio;

    public ServicoBuscaMunicipioPorCodigo(IRepositorioMunicipio repositorioMunicipio)
    {
        this._repositorioMunicipio = repositorioMunicipio;
    }

    public async Task<Entidades.Municipio?> BuscarPorCodigoAsync(int codigo, CancellationToken cancellationToken)
    {
        if (codigo < 0)
        {
            AddNotification(nameof(codigo), Mensagens.CodigoIbgeNaoInformado);

            return await Task.FromResult<Entidades.Municipio?>(null);
        }

        var municipioEncontrado = await _repositorioMunicipio.BuscarPorCodigoAsync(codigo);

        if (municipioEncontrado is null)
        {
            return await Task.FromResult<Entidades.Municipio?>(null);
        }

        return await Task.FromResult(municipioEncontrado);
    }
}