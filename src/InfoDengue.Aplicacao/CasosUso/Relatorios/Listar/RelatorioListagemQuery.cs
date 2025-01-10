using InfoDengue.Aplicacao.DTOs;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Relatorios.Listar;

public class RelatorioListagemQuery : IRequest<Result<RelatorioListagemQueryResult>>
{
}