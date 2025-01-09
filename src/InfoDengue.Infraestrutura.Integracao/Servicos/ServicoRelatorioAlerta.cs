using InfoDengue.Infraestrutura.Integracao.Contratos;
using InfoDengue.Infraestrutura.Integracao.DTOs;
using Refit;

namespace InfoDengue.Infraestrutura.Integracao.Servicos;

public class ServicoRelatorioAlerta : IServicoRelatorioAlerta
{
    private readonly string _urlBase = "https://info.dengue.mat.br/api";

    public async Task<RelatorioAlerta> ObterRelatorio(string municipio, int codigoIbge, string arbovirose, int semanaInicio, int semanaFim, int anoInicio, int anoFim)
    {
        var servicoApiAlertaDengue = RestService.For<IServicoApiAlertaDengue>(_urlBase);

        var relatorio = await servicoApiAlertaDengue.GetRelatorioAlertaAsync(codigoIbge, arbovirose, format: "json", semanaInicio, semanaFim, anoInicio, anoFim);

        return relatorio;
    }
}