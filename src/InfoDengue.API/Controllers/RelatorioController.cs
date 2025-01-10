using InfoDengue.Aplicacao.CasosUso.Relatorios.Listar;
using InfoDengue.Aplicacao.CasosUso.Solicitante.Listar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoDengue.API.Controllers;

[Route("api/relatorios")]
public class RelatorioController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public RelatorioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Lista de solicitantes cadastrados
    /// </summary>
    /// <returns>Lista de solicitantes encontrados</returns>
    [HttpGet("registro-atividades")]
    public async Task<IActionResult> Listar()
    {
        var solicitarRelatoriosConsultados = new RelatorioListagemQuery();

        var result = await _mediator.Send(solicitarRelatoriosConsultados);

        if (result is null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        if (!result.Data!.Any())
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}