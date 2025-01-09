using InfoDengue.Aplicacao.DTOs;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Usuario.BuscarPorId;

public class UsuarioBuscaPorIdQuery : IRequest<Result<UsuarioBuscaPorIdQueryResult>>
{
    public int Id { get; set; }
}