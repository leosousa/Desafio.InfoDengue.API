using AutoMapper;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;
using InfoDengue.Dominio.Recursos;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Solicitante.BuscarPorId;

public class SolicitanteBuscaPorIdQueryHandler :
    IRequestHandler<SolicitanteBuscaPorIdQuery, Result<SolicitanteBuscaPorIdQueryResult>>
{
    private readonly IServicoBuscaSolicitantePorId _servicoBuscaUsuarioPorId;
    private readonly IMapper _mapper;

    public SolicitanteBuscaPorIdQueryHandler(IServicoBuscaSolicitantePorId servicoBuscaUsuarioPorId, IMapper mapper)
    {
        _servicoBuscaUsuarioPorId = servicoBuscaUsuarioPorId;
        _mapper = mapper;
    }

    public async Task<Result<SolicitanteBuscaPorIdQueryResult>> Handle(SolicitanteBuscaPorIdQuery request, CancellationToken cancellationToken)
    {
        Result<SolicitanteBuscaPorIdQueryResult> result = new();

        if (request is null)
        {
            result.AddNotification(nameof(SolicitanteBuscaPorIdQuery.Id), Mensagens.CodigoSolicitanteNaoInformado);

            return await Task.FromResult(result);
        }

        var assuntoEncontrado = await _servicoBuscaUsuarioPorId.BuscarPorIdAsync(request.Id, cancellationToken);

        if (!_servicoBuscaUsuarioPorId.IsValid)
        {
            result.AddNotifications(_servicoBuscaUsuarioPorId.Notifications);

            return await Task.FromResult(result);
        }

        result.Data = _mapper.Map<SolicitanteBuscaPorIdQueryResult>(assuntoEncontrado);

        return await Task.FromResult(result);
    }
}