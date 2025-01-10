using InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorMunicipio.BuscarRelatorioPorMunicipio;
using InfoDengue.Aplicacao.CasosUso.Epidemiologia.ListarTotaisCasosArbovirosePorNomeMunicipio;
using InfoDengue.Aplicacao.DTOs;
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
    [HttpPost("municipios/nome")]
    public async Task<IActionResult> GerarRelatorioPorNomeMunicipio(
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

    /// <summary>
    /// Gera relatório de dados epidemiológicos a partir dos filtros informados na API do Alerta Dengue
    /// </summary>
    /// <param name="filtros">Filtros para geração do relatório</param>
    /// <returns>Lista com dados epidemiológicos encontrados</returns>
    [HttpPost("municipios/codigo")]
    public async Task<IActionResult> GerarRelatorioPorCodigoIbge(
        [FromBody] RelatorioEpidemiologicoCommand filtros)
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

    /// <summary>
    /// Gera relatório com totais de casos epidemiológicos a partir dos filtros informados na API do Alerta Dengue
    /// </summary>
    /// <param name="filtros">Filtros para geração do relatório</param>
    /// <returns>Lista com dados epidemiológicos encontrados</returns>
    [HttpPost("municipios/codigo/totais")]
    public async Task<IActionResult> GerarRelatorioTotaisCasosPorCodigoIbge(
        [FromBody] RelatorioEpidemiologicoTotalCommand filtros)
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

    /// <summary>
    /// Gera relatório com totais de casos epidemiológicos a partir dos filtros informados na API do Alerta Dengue
    /// </summary>
    /// <param name="filtros">Filtros para geração do relatório</param>
    /// <returns>Lista com dados epidemiológicos encontrados</returns>
    [HttpPost("municipios/nome/totais")]
    public async Task<IActionResult> GerarRelatorioTotaisCasosPorNomeMunicipio(
        [FromBody] ListarTotaisCasosArbovirosePorNomeMunicipioQuery filtros)
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
}