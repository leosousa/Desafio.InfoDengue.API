using InfoDengue.Aplicacao.Contratos;
using InfoDengue.Aplicacao.Servicos.Relatorio;

namespace Microsoft.Extensions.DependencyInjection;

public static class AplicacaoDependencyConfig
{
    public static void AdicionarDependenciasAplicacao(this IServiceCollection services)
    {
        services.AddScoped<IServicoGeradorRelatorioEpidemiologico, ServicoGeradorRelatorioEpidemiologico>();
    }
}