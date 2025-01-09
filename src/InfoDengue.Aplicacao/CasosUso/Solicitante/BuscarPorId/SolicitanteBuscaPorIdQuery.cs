using InfoDengue.Aplicacao.DTOs;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Solicitante.BuscarPorId;

public class SolicitanteBuscaPorIdQuery : IRequest<Result<SolicitanteBuscaPorIdQueryResult>>
{
    public int Id { get; set; }
}