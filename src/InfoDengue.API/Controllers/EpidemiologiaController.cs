using InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorMunicipio.BuscarRelatorioPorMunicipio;
using InfoDengue.Dominio.Enumeracoes;
using InfoDengue.Infraestrutura.Integracao.Contratos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoDengue.API.Controllers;

[Route("api/epidemiologia/relatorios")]
public class EpidemiologiaController : ApiControllerBase
{
    private readonly IMediator _mediator;
    private readonly IServicoRelatorioAlerta _servicoRelatorioAlerta;
    private readonly int anoAtual = DateTime.Today.Year;

    public EpidemiologiaController(IMediator mediator, IServicoRelatorioAlerta servicoRelatorioAlerta)
    {
        _mediator = mediator;
        _servicoRelatorioAlerta = servicoRelatorioAlerta;
    }

    /// <summary>
    /// Gera relatório de dados epidemiológicos a partir dos filtros informados na API do Alerta Dengue
    /// </summary>
    /// <param name="filtros">Filtros para geração do relatório</param>
    /// <returns>Lista com dados epidemiológicos encontrados</returns>
    [HttpPost("municipios")]
    public async Task<IActionResult> GerarRelatorioPorMunicipio(
        [FromBody] RelatorioEpidemiologicoPorMunicipioCommand filtros)
    {
        var result = await _mediator.Send(filtros);

        if (result is null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return result.ResultadoAcao switch
        {
            EResultadoAcaoServico.NaoEncontrado => NotFound(result),
            EResultadoAcaoServico.ParametrosInvalidos => BadRequest(result),
            EResultadoAcaoServico.Erro => StatusCode(StatusCodes.Status500InternalServerError),
            EResultadoAcaoServico.Sucesso => Ok(result),
            _ => throw new NotImplementedException()
        };
    }

    ///// <summary>
    ///// Busca dados epidemiológicos a partir dos filtros informados
    ///// </summary>
    ///// <param name="descricao">Descrição do assuntos</param>
    ///// <returns>Lista com dados epidemiológicos encontrados</returns>
    //[HttpGet]
    //public async Task<IActionResult> Listar(
    //    [FromQuery] string municipio = "",
    //    [FromQuery] int codigoIbge = 3304557,
    //    [FromQuery] string arbovirose = "dengue",
    //    [FromQuery] int semanaInicio = 1,
    //    [FromQuery] int semanaFim = 50,
    //    [FromQuery] int anoInicio = 2017,
    //    [FromQuery] int anoFim = 2017)
    //{
    //    //var filtros = new AssuntoListaPaginadaQuery
    //    //{
    //    //    Descricao = descricao,
    //    //};

    //    //var result = await _mediator.Send(filtros);

    //    if (anoFim == 0)
    //    {
    //        anoFim = DateTime.Today.Year;
    //    }

    //    var result = await _servicoRelatorioAlerta.ObterRelatorio(municipio, codigoIbge, arbovirose, semanaInicio, semanaFim, anoInicio, anoFim);

    //    if (result is null)
    //    {
    //        return StatusCode(StatusCodes.Status500InternalServerError);
    //    }

    //    if (!result.Any())
    //    {
    //        return NotFound(result);
    //    }

    //    return Ok(result);
    //}
}