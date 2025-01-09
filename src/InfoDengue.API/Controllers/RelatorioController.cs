using InfoDengue.Infraestrutura.Integracao.Contratos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoDengue.API.Controllers;

public class RelatorioController : ApiControllerBase
{
    private readonly IMediator _mediator;
    private readonly IServicoRelatorioAlerta _servicoRelatorioAlerta;
    private readonly int anoAtual = DateTime.Today.Year;

    public RelatorioController(IMediator mediator, IServicoRelatorioAlerta servicoRelatorioAlerta)
    {
        _mediator = mediator;
        _servicoRelatorioAlerta = servicoRelatorioAlerta;
    }

    /// <summary>
    /// Busca dados epidemiológicos a partir dos filtros informados
    /// </summary>
    /// <param name="descricao">Descrição do assuntos</param>
    /// <returns>Lista com dados epidemiológicos encontrados</returns>
    [HttpGet]
    public async Task<IActionResult> Listar(
        [FromQuery] string municipio = "",
        [FromQuery] int codigoIbge = 3304557,
        [FromQuery] string arbovirose = "dengue",
        [FromQuery] int semanaInicio = 1,
        [FromQuery] int semanaFim = 50,
        [FromQuery] int anoInicio = 2017,
        [FromQuery] int anoFim = 2017)
    {
        //var filtros = new AssuntoListaPaginadaQuery
        //{
        //    Descricao = descricao,
        //};

        //var result = await _mediator.Send(filtros);

        if (anoFim == 0)
        {
            anoFim = DateTime.Today.Year;
        }

        var result = await _servicoRelatorioAlerta.ObterRelatorio(municipio, codigoIbge, arbovirose, semanaInicio, semanaFim, anoInicio, anoFim);

        if (result is null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        if (!result.Any())
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}