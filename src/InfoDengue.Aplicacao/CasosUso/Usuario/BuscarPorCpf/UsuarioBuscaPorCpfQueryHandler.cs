using AutoMapper;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Dominio.Contratos.Servicos.Usuario;
using InfoDengue.Dominio.Recursos;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Usuario.BuscarPorCpf;

public class UsuarioBuscaPorCpfQueryHandler :
    IRequestHandler<UsuarioBuscaPorCpfQuery, Result<UsuarioBuscaPorCpfQueryResult>>
{
    private readonly IServicoBuscaUsuarioPorCpf _servicoBuscaUsuarioPorCpf;
    private readonly IMapper _mapper;

    public UsuarioBuscaPorCpfQueryHandler(IServicoBuscaUsuarioPorCpf servicoBuscaUsuarioPorCpf, IMapper mapper)
    {
        _servicoBuscaUsuarioPorCpf = servicoBuscaUsuarioPorCpf;
        _mapper = mapper;
    }

    public async Task<Result<UsuarioBuscaPorCpfQueryResult>> Handle(UsuarioBuscaPorCpfQuery request, CancellationToken cancellationToken)
    {
        Result<UsuarioBuscaPorCpfQueryResult> result = new();

        if (request is null)
        {
            result.AddNotification(nameof(UsuarioBuscaPorCpfQuery.Cpf), Mensagens.CpfNaoInformado);

            return await Task.FromResult(result);
        }

        var assuntoEncontrado = await _servicoBuscaUsuarioPorCpf.BuscarPorCpfAsync(request.Cpf, cancellationToken);

        if (!_servicoBuscaUsuarioPorCpf.IsValid)
        {
            result.AddNotifications(_servicoBuscaUsuarioPorCpf.Notifications);

            return await Task.FromResult(result);
        }

        result.Data = _mapper.Map<UsuarioBuscaPorCpfQueryResult>(assuntoEncontrado);

        return await Task.FromResult(result);
    }
}