using FluentValidation;
using InfoDengue.Dominio.Contratos.Servicos.Municipio;
using InfoDengue.Dominio.Contratos.Servicos.Relatorio;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;
using InfoDengue.Dominio.Servicos.Municipio;
using InfoDengue.Dominio.Servicos.Relatorio;
using InfoDengue.Dominio.Servicos.Solicitante;
using InfoDengue.Dominio.Validadores;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;

public static class DominioDependencyConfig
{
    public static void AdicionarDependenciasDominio(this IServiceCollection services)
    {
        services.AddScoped<IServicoCadastroSolicitante, ServicoCadastroSolicitante>();
        services.AddScoped<IServicoBuscaSolicitantePorId, ServicoBuscaSolicitantePorId>();
        services.AddScoped<IServicoBuscaSolicitantePorCpf, ServicoBuscaSolicitantePorCpf>();
        services.AddScoped<IServicoBuscaMunicipioPorNome, ServicoBuscaMunicipioPorNome>();
        services.AddScoped<IServicoBuscaMunicipioPorCodigo, ServicoBuscaMunicipioPorCodigo>();
        services.AddScoped<IServicoCadastroRelatorio, ServicoCadastroRelatorio>();
        services.AddScoped<IServicoListagemSolicitante, ServicoListagemSolicitante>();
        services.AddScoped<IServicoListagemRelatorio, ServicoListagemRelatorio>();
        
        services.AddValidatorsFromAssemblyContaining<SolicitanteValidador>();
        services.AddValidatorsFromAssemblyContaining<RelatorioValidador>();
    }
}