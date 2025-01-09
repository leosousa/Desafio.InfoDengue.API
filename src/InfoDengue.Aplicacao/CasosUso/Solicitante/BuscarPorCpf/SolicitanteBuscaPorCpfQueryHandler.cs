using AutoMapper;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;
using InfoDengue.Dominio.Recursos;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Solicitante.BuscarPorCpf;

public class SolicitanteBuscaPorCpfQueryHandler :
    IRequestHandler<SolicitanteBuscaPorCpfQuery, Result<SolicitanteBuscaPorCpfQueryResult>>
{
    private readonly IServicoBuscaSolicitantePorCpf _servicoBuscaUsuarioPorCpf;
    private readonly IMapper _mapper;

    public SolicitanteBuscaPorCpfQueryHandler(IServicoBuscaSolicitantePorCpf servicoBuscaUsuarioPorCpf, IMapper mapper)
    {
        _servicoBuscaUsuarioPorCpf = servicoBuscaUsuarioPorCpf;
        _mapper = mapper;
    }

    public async Task<Result<SolicitanteBuscaPorCpfQueryResult>> Handle(SolicitanteBuscaPorCpfQuery request, CancellationToken cancellationToken)
    {
        Result<SolicitanteBuscaPorCpfQueryResult> result = new();

        if (request is null)
        {
            result.AddNotification(nameof(SolicitanteBuscaPorCpfQuery.Cpf), Mensagens.CpfNaoInformado);

            return await Task.FromResult(result);
        }

        var assuntoEncontrado = await _servicoBuscaUsuarioPorCpf.BuscarPorCpfAsync(request.Cpf, cancellationToken);

        if (!_servicoBuscaUsuarioPorCpf.IsValid)
        {
            result.AddNotifications(_servicoBuscaUsuarioPorCpf.Notifications);

            return await Task.FromResult(result);
        }

        result.Data = _mapper.Map<SolicitanteBuscaPorCpfQueryResult>(assuntoEncontrado);

        return await Task.FromResult(result);
    }
}