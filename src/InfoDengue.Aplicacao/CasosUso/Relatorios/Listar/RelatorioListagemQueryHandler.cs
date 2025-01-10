using AutoMapper;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Aplicacao.Servicos;
using InfoDengue.Dominio.Contratos.Servicos.Relatorio;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Relatorios.Listar;

public class RelatorioListagemQueryHandler : ServicoAplicacao,
    IRequestHandler<RelatorioListagemQuery, Result<RelatorioListagemQueryResult>>
{
    private readonly IMapper _mapper;
    private readonly IServicoListagemRelatorio _servicoListagemRelatorio;

    public RelatorioListagemQueryHandler(IMapper mapper, IServicoListagemRelatorio servicoListagemRelatorio)
    {
        _mapper = mapper;
        _servicoListagemRelatorio = servicoListagemRelatorio;
    }

    public async Task<Result<RelatorioListagemQueryResult>> Handle(RelatorioListagemQuery request, CancellationToken cancellationToken)
    {
        Result<RelatorioListagemQueryResult> result = new();

        var relatorio = await _servicoListagemRelatorio.ListarAsync(cancellationToken);

        result.Data = _mapper.Map<RelatorioListagemQueryResult>(relatorio);

        return await Task.FromResult(result);
    }
}
