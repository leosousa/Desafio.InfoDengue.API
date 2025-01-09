using InfoDengue.Aplicacao.DTOs;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Solicitante.Cadastrar;

public class SolicitanteCadastroCommand : IRequest<Result<SolicitanteCadastroCommandResult>>
{
    public string Nome { get; set; }

    public string Cpf { get; set; }
}