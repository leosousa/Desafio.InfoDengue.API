using AutoMapper;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Aplicacao.Servicos;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace InfoDengue.Aplicacao.CasosUso.Solicitante.Listar;

public class SolicitanteListagemQueryHandler : ServicoAplicacao,
     IRequestHandler<SolicitanteListagemQuery, Result<SolicitanteListagemQueryResult>>
{
    private readonly IMapper _mapper;
    private readonly IServicoListagemSolicitante _servicoListagemSolicitante;

    public SolicitanteListagemQueryHandler(
        IMapper mapper, 
        IServicoListagemSolicitante servicoListagemSolicitante)
    {
        _mapper = mapper;
        _servicoListagemSolicitante = servicoListagemSolicitante;
    }

    public async Task<Result<SolicitanteListagemQueryResult>> Handle(SolicitanteListagemQuery request, CancellationToken cancellationToken)
    {
        Result<SolicitanteListagemQueryResult> result = new();

        var solicitantes = await _servicoListagemSolicitante.ListarAsync(cancellationToken);

        result.Data = _mapper.Map<SolicitanteListagemQueryResult>(solicitantes);

        return await Task.FromResult(result);
    }
}