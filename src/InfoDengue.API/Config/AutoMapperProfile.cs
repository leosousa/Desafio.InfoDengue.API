using AutoMapper;
using InfoDengue.Aplicacao.CasosUso.Solicitante.BuscarPorCpf;
using InfoDengue.Aplicacao.CasosUso.Solicitante.BuscarPorId;
using InfoDengue.Aplicacao.CasosUso.Solicitante.Cadastrar;
using InfoDengue.Dominio.Entidades;

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
    }
}