using AutoMapper;
using InfoDengue.Aplicacao.CasosUso.Usuario.BuscarPorCpf;
using InfoDengue.Aplicacao.CasosUso.Usuario.BuscarPorId;
using InfoDengue.Aplicacao.CasosUso.Usuario.Cadastrar;
using InfoDengue.Dominio.Entidades;

namespace InfoDengue.API.Config;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Usuário
        CreateMap<UsuarioCadastroCommand, Usuario>();
        CreateMap<Usuario, UsuarioCadastroCommandResult>();

        CreateMap<Usuario, UsuarioBuscaPorIdQueryResult>();

        CreateMap<Usuario, UsuarioBuscaPorCpfQueryResult>();
    }
}