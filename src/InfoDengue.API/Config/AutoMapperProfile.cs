using AutoMapper;
using InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorCodigoIbge;
using InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorMunicipio.BuscarRelatorioPorMunicipio;
using InfoDengue.Aplicacao.CasosUso.Relatorios.Listar;
using InfoDengue.Aplicacao.CasosUso.Solicitante.BuscarPorCpf;
using InfoDengue.Aplicacao.CasosUso.Solicitante.BuscarPorId;
using InfoDengue.Aplicacao.CasosUso.Solicitante.Cadastrar;
using InfoDengue.Aplicacao.CasosUso.Solicitante.Listar;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Dominio.Entidades;
using InfoDengue.Infraestrutura.Integracao.DTOs;

namespace InfoDengue.API.Config;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Usuário
        CreateMap<SolicitanteCadastroCommand, Solicitante>();
        CreateMap<Solicitante, SolicitanteCadastroCommandResult>();

        CreateMap<Solicitante, SolicitanteBuscaPorIdQueryResult>();

        CreateMap<Solicitante, SolicitanteBuscaPorCpfQueryResult>();

        //CreateMap<RelatorioAlertaItem, RelatorioEpidemiologicoPorMunicipioItemCommandResult>()
        //    .ForMember(dest => dest.DataInicioSemana, opt => opt.MapFrom(src => src.data_iniSE))
        //    .ForMember(dest => dest.Semana, opt => opt.MapFrom(src => src.SE))
        //    .ForMember(dest => dest.NumeroEstimadoCasosPorSemana, opt => opt.MapFrom(src => src.casos_est))
        //    .ForMember(dest => dest.IntervaloMinimoCredibilidadeNumeroEstimadoCasos, opt => opt.MapFrom(src => src.casos_est_min))
        //    .ForMember(dest => dest.IntervaloMaximoCredibilidadeNumeroEstimadoCasos, opt => opt.MapFrom(src => src.casos_est_max))
        //    .ForMember(dest => dest.NumeroCasosNotificadosPorSemana, opt => opt.MapFrom(src => src.casos))
        //    .ForMember(dest => dest.ProbabilidadeRt1, opt => opt.MapFrom(src => src.p_rt1))
        //    .ForMember(dest => dest.TaxaIncidenciaEstimada100k, opt => opt.MapFrom(src => src.p_inc100k))
        //    .ForMember(dest => dest.DivisaoSubmunicipal, opt => opt.MapFrom(src => src.Localidade_id))
        //    .ForMember(dest => dest.NivelAlerta, opt => opt.MapFrom(src => src.nivel))
        //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
        //    .ForMember(dest => dest.VersaoModelo, opt => opt.MapFrom(src => src.versao_modelo))
        //    .ForMember(dest => dest.Tweet, opt => opt.MapFrom(src => src.tweet))
        //    .ForMember(dest => dest.EstimativaPontualNumeroReprodutivoCasos, opt => opt.MapFrom(src => src.Rt))
        //    .ForMember(dest => dest.PopulacaoEstimada, opt => opt.MapFrom(src => src.pop))
        //    .ForMember(dest => dest.MediaTemperaturaMinimaDiariaSemana, opt => opt.MapFrom(src => src.tempmin))
        //    .ForMember(dest => dest.MediaUmidadeRelativaMaximaDiariaSemana, opt => opt.MapFrom(src => src.umidmax))
        //    .ForMember(dest => dest.ReceptividadeCimatica, opt => opt.MapFrom(src => src.receptivo))
        //    .ForMember(dest => dest.EvidenciaTransmissaoSustentada, opt => opt.MapFrom(src => src.transmissao))
        //    .ForMember(dest => dest.IncidenciaEstimadaAbaixoLimiarPrePandemia, opt => opt.MapFrom(src => src.nivel_inc))
        //    .ForMember(dest => dest.umidmed, opt => opt.MapFrom(src => src.umidmed))
        //    .ForMember(dest => dest.umidmin, opt => opt.MapFrom(src => src.umidmin))
        //    .ForMember(dest => dest.tempmed, opt => opt.MapFrom(src => src.tempmed))
        //    .ForMember(dest => dest.tempmax, opt => opt.MapFrom(src => src.tempmax))
        //    .ForMember(dest => dest.casprov, opt => opt.MapFrom(src => src.casprov))
        //    .ForMember(dest => dest.casprov_est, opt => opt.MapFrom(src => src.casprov_est))
        //    .ForMember(dest => dest.casprov_est_min, opt => opt.MapFrom(src => src.casprov_est_min))
        //    .ForMember(dest => dest.casprov_est_max, opt => opt.MapFrom(src => src.casprov_est_max))
        //    .ForMember(dest => dest.casconf, opt => opt.MapFrom(src => src.casconf))
        //    .ForMember(dest => dest.NumeroCasosAcumuladoAno, opt => opt.MapFrom(src => src.notif_accum_year));

        CreateMap<RelatorioAlertaItem, RelatorioEpidemiologicoItemResult>()
            .ForMember(dest => dest.DataInicioSemana, opt => opt.MapFrom(src => src.data_iniSE))
            .ForMember(dest => dest.Semana, opt => opt.MapFrom(src => src.SE))
            .ForMember(dest => dest.NumeroEstimadoCasosPorSemana, opt => opt.MapFrom(src => src.casos_est))
            .ForMember(dest => dest.IntervaloMinimoCredibilidadeNumeroEstimadoCasos, opt => opt.MapFrom(src => src.casos_est_min))
            .ForMember(dest => dest.IntervaloMaximoCredibilidadeNumeroEstimadoCasos, opt => opt.MapFrom(src => src.casos_est_max))
            .ForMember(dest => dest.NumeroCasosNotificadosPorSemana, opt => opt.MapFrom(src => src.casos))
            .ForMember(dest => dest.ProbabilidadeRt1, opt => opt.MapFrom(src => src.p_rt1))
            .ForMember(dest => dest.TaxaIncidenciaEstimada100k, opt => opt.MapFrom(src => src.p_inc100k))
            .ForMember(dest => dest.DivisaoSubmunicipal, opt => opt.MapFrom(src => src.Localidade_id))
            .ForMember(dest => dest.NivelAlerta, opt => opt.MapFrom(src => src.nivel))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.VersaoModelo, opt => opt.MapFrom(src => src.versao_modelo))
            .ForMember(dest => dest.Tweet, opt => opt.MapFrom(src => src.tweet))
            .ForMember(dest => dest.EstimativaPontualNumeroReprodutivoCasos, opt => opt.MapFrom(src => src.Rt))
            .ForMember(dest => dest.PopulacaoEstimada, opt => opt.MapFrom(src => src.pop))
            .ForMember(dest => dest.MediaTemperaturaMinimaDiariaSemana, opt => opt.MapFrom(src => src.tempmin))
            .ForMember(dest => dest.MediaUmidadeRelativaMaximaDiariaSemana, opt => opt.MapFrom(src => src.umidmax))
            .ForMember(dest => dest.ReceptividadeCimatica, opt => opt.MapFrom(src => src.receptivo))
            .ForMember(dest => dest.EvidenciaTransmissaoSustentada, opt => opt.MapFrom(src => src.transmissao))
            .ForMember(dest => dest.IncidenciaEstimadaAbaixoLimiarPrePandemia, opt => opt.MapFrom(src => src.nivel_inc))
            .ForMember(dest => dest.umidmed, opt => opt.MapFrom(src => src.umidmed))
            .ForMember(dest => dest.umidmin, opt => opt.MapFrom(src => src.umidmin))
            .ForMember(dest => dest.tempmed, opt => opt.MapFrom(src => src.tempmed))
            .ForMember(dest => dest.tempmax, opt => opt.MapFrom(src => src.tempmax))
            .ForMember(dest => dest.casprov, opt => opt.MapFrom(src => src.casprov))
            .ForMember(dest => dest.casprov_est, opt => opt.MapFrom(src => src.casprov_est))
            .ForMember(dest => dest.casprov_est_min, opt => opt.MapFrom(src => src.casprov_est_min))
            .ForMember(dest => dest.casprov_est_max, opt => opt.MapFrom(src => src.casprov_est_max))
            .ForMember(dest => dest.casconf, opt => opt.MapFrom(src => src.casconf))
            .ForMember(dest => dest.NumeroCasosAcumuladoAno, opt => opt.MapFrom(src => src.notif_accum_year));

        CreateMap<RelatorioEpidemiologicoTotalCommand, RelatorioEpidemiologicoCommand>();

        CreateMap<Solicitante, SolicitanteListagemItemQueryResult>();

        CreateMap<Relatorio, RelatorioListagemItemQueryResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Arbovirose, opt => opt.MapFrom(src => src.Arbovirose))
            .ForMember(dest => dest.DataSolicitacao, opt => opt.MapFrom(src => src.DataSolicitacao))
            .ForMember(dest => dest.SemanaInicio, opt => opt.MapFrom(src => src.SemanaInicio))
            .ForMember(dest => dest.SemanaTermino, opt => opt.MapFrom(src => src.SemanaTermino))
            .ForMember(dest => dest.CodigoIbge, opt => opt.MapFrom(src => src.Municipio.CodigoIbge))
            .ForMember(dest => dest.Municipio, opt => opt.MapFrom(src => src.Municipio.Nome))
            .ForMember(dest => dest.Solicitante, opt => opt.MapFrom(src => src.Solicitante.Nome));
    }
}