using InfoDengue.Aplicacao.CasosUso.Usuario.BuscarPorId;
using InfoDengue.Aplicacao.CasosUso.Usuario.Cadastrar;
using InfoDengue.Dominio.Enumeracoes;
using InfoDengue.Dominio.Recursos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoDengue.API.Controllers;

[Route("api/usuarios")]
public class UsuarioController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Cadastra um novo usuário
    /// </summary>
    /// <param name="usuario">Usuário a ser cadastrado</param>
    /// <returns>Id do novo usuário cadastrado</returns>
    [HttpPost]
    public async Task<IActionResult> Cadastrar(UsuarioCadastroCommand usuario)
    {
        var assuntoCadastrado = await _mediator.Send(usuario);

        if (assuntoCadastrado is null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return assuntoCadastrado.ResultadoAcao switch
        {
            EResultadoAcaoServico.NaoEncontrado => NotFound(assuntoCadastrado),
            EResultadoAcaoServico.ParametrosInvalidos => BadRequest(assuntoCadastrado),
            EResultadoAcaoServico.Erro => StatusCode(StatusCodes.Status500InternalServerError),
            EResultadoAcaoServico.Suceso => CreatedAtAction("BuscarPorId",
                new { id = assuntoCadastrado.Data.Id },
                assuntoCadastrado.Data
            ),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    /// Busca um usuário já cadastrado pelo seu identificador
    /// </summary>
    /// <param name="id">Identificador do usuário</param>
    /// <returns>Usuário encontrado</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var result = await _mediator.Send(new UsuarioBuscaPorIdQuery { Id = id });

        if (result is null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        if (result.Notifications.Any())
        {
            return BadRequest(result);
        }

        if (result.Data is null)
        {
            result.AddNotification("Usuario", Mensagens.UsuarioNaoEncontrado);

            return NotFound(result);
        }

        return Ok(result);
    }
}