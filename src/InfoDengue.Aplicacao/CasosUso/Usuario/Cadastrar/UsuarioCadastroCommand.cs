using InfoDengue.Aplicacao.DTOs;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Usuario.Cadastrar;

public class UsuarioCadastroCommand : IRequest<Result<UsuarioCadastroCommandResult>>
{
    public string Nome { get; set; }

    public string Cpf { get; set; }
}