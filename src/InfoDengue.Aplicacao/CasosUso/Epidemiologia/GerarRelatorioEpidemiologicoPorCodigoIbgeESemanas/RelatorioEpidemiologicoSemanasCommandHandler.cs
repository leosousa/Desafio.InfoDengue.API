using AutoMapper;
using InfoDengue.Aplicacao.Contratos;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Aplicacao.Servicos;
using InfoDengue.Aplicacao.Servicos.Relatorio;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorCodigoIbgeESemanas;

public class RelatorioEpidemiologicoSemanasCommandHandler : ServicoAplicacao,
    IRequestHandler<RelatorioEpidemiologicoSemanasCommand, Result<RelatorioEpidemiologicoSemanasCommandResult>>
{
    private readonly IMapper _mapper;
    private readonly IServicoGeradorRelatorioEpidemiologicoPorSemanas _servicoGeradorRelatorioEpidemiologicoPorSemanas;

    public RelatorioEpidemiologicoSemanasCommandHandler(
        IMapper mapper,
        IServicoGeradorRelatorioEpidemiologicoPorSemanas servicoGeradorRelatorioEpidemiologicoPorSemanas)
    {
        _mapper = mapper;
        _servicoGeradorRelatorioEpidemiologicoPorSemanas = servicoGeradorRelatorioEpidemiologicoPorSemanas;
    }

    public async Task<Result<RelatorioEpidemiologicoSemanasCommandResult>> Handle(RelatorioEpidemiologicoSemanasCommand command, CancellationToken cancellationToken)
    {
        var result = await _servicoGeradorRelatorioEpidemiologicoPorSemanas.GerarRelatorioEpidemiologico(command, cancellationToken);

        return await Task.FromResult(result);
    }
}