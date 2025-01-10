using InfoDengue.Infraestrutura.Integracao.Configuracoes;
using InfoDengue.Infraestrutura.Integracao.Contratos;
using InfoDengue.Infraestrutura.Integracao.DTOs;
using Microsoft.Extensions.Options;
using Refit;

namespace InfoDengue.Infraestrutura.Integracao.Servicos;

public class ServicoRelatorioAlerta : IServicoRelatorioAlerta
{
    private readonly string _baseUrl;

    public ServicoRelatorioAlerta(IOptions<AlertaDengueAPI> options)
    {
        _baseUrl = options.Value.BaseUrl;
    }

    public async Task<RelatorioAlerta> ObterRelatorio(int codigoIbge, string arbovirose, int semanaInicio, int semanaFim, int anoInicio, int anoFim)
    {
        var servicoApiAlertaDengue = RestService.For<IServicoApiAlertaDengue>(_baseUrl);

        var relatorio = await servicoApiAlertaDengue.GetRelatorioAlertaAsync(codigoIbge, arbovirose, format: "json", semanaInicio, semanaFim, anoInicio, anoFim);

        return await Task.FromResult(relatorio);
    }
}