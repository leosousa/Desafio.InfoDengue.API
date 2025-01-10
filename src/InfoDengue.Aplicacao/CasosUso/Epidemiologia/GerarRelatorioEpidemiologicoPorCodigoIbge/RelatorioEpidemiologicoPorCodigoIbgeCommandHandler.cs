using AutoMapper;
using InfoDengue.Aplicacao.Contratos;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Aplicacao.Servicos;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorCodigoIbge;

internal class RelatorioEpidemiologicoPorCodigoIbgeCommandHandler : ServicoAplicacao,
    IRequestHandler<RelatorioEpidemiologicoCommand, Result<RelatorioEpidemiologicoCommandResult>>
{
    private readonly IMapper _mapper;
    private readonly IServicoGeradorRelatorioEpidemiologico _servicoGeradorRelatorioEpidemiologico;

    public RelatorioEpidemiologicoPorCodigoIbgeCommandHandler(IMapper mapper, IServicoGeradorRelatorioEpidemiologico servicoGeradorRelatorioEpidemiologico)
    {
        _mapper = mapper;
        _servicoGeradorRelatorioEpidemiologico = servicoGeradorRelatorioEpidemiologico;
    }

    public async Task<Result<RelatorioEpidemiologicoCommandResult>> Handle(RelatorioEpidemiologicoCommand command, CancellationToken cancellationToken)
    {
        var result = await _servicoGeradorRelatorioEpidemiologico.GerarRelatorioEpidemiologico(command, cancellationToken);

        return await Task.FromResult(result);
    }
}