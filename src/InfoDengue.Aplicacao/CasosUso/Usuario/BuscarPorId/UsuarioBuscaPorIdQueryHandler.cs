using AutoMapper;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Dominio.Contratos.Servicos.Usuario;
using InfoDengue.Dominio.Recursos;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Usuario.BuscarPorId;

public class UsuarioBuscaPorIdQueryHandler :
    IRequestHandler<UsuarioBuscaPorIdQuery, Result<UsuarioBuscaPorIdQueryResult>>
{
    private readonly IServicoBuscaUsuarioPorId _servicoBuscaUsuarioPorId;
    private readonly IMapper _mapper;

    public UsuarioBuscaPorIdQueryHandler(IServicoBuscaUsuarioPorId servicoBuscaUsuarioPorId, IMapper mapper)
    {
        _servicoBuscaUsuarioPorId = servicoBuscaUsuarioPorId;
        _mapper = mapper;
    }

    public async Task<Result<UsuarioBuscaPorIdQueryResult>> Handle(UsuarioBuscaPorIdQuery request, CancellationToken cancellationToken)
    {
        Result<UsuarioBuscaPorIdQueryResult> result = new();

        if (request is null)
        {
            result.AddNotification(nameof(UsuarioBuscaPorIdQuery.Id), Mensagens.CodigoUsuarioNaoInformado);

            return await Task.FromResult(result);
        }

        var assuntoEncontrado = await _servicoBuscaUsuarioPorId.BuscarPorIdAsync(request.Id, cancellationToken);

        if (!_servicoBuscaUsuarioPorId.IsValid)
        {
            result.AddNotifications(_servicoBuscaUsuarioPorId.Notifications);

            return await Task.FromResult(result);
        }

        result.Data = _mapper.Map<UsuarioBuscaPorIdQueryResult>(assuntoEncontrado);

        return await Task.FromResult(result);
    }
}