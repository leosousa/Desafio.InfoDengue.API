using InfoDengue.Aplicacao.DTOs;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Solicitante.Listar;

public class SolicitanteListagemQuery : IRequest<Result<SolicitanteListagemQueryResult>>
{
}