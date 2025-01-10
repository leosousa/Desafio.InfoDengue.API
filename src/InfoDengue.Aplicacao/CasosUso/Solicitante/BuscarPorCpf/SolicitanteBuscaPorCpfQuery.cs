using InfoDengue.Aplicacao.CasosUso.Solicitante.BuscarPorId;
using InfoDengue.Aplicacao.DTOs;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Solicitante.BuscarPorCpf;

public class SolicitanteBuscaPorCpfQuery : IRequest<Result<SolicitanteBuscaPorCpfQueryResult>>
{
    public string Cpf { get; set; }
}