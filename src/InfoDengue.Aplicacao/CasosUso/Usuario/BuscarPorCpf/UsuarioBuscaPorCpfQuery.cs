using InfoDengue.Aplicacao.CasosUso.Usuario.BuscarPorId;
using InfoDengue.Aplicacao.DTOs;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Usuario.BuscarPorCpf;

public class UsuarioBuscaPorCpfQuery : IRequest<Result<UsuarioBuscaPorCpfQueryResult>>
{
    public string Cpf { get; set; }
}