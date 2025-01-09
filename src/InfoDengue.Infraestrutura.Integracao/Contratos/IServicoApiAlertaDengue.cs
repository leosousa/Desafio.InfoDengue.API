using InfoDengue.Infraestrutura.Integracao.DTOs;
using Refit;

namespace InfoDengue.Infraestrutura.Integracao.Contratos;

internal interface IServicoApiAlertaDengue
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="geocode">Código IBGE da cidade</param>
    /// <param name="disease">Tipo de doença a ser consultada. Opções válidas: dengue, chikungunya, zika</param>
    /// <param name="format">Formato de saída dos dados. Opções válidas: json, csv</param>
    /// <param name="ew_start">Semana epidemiológica de início da consulta. Opções válidas: 1 ao 53</param>
    /// <param name="ew_end">Semana epidemiológica de término da consultaa. Opções válidas: 1 ao 53</param>
    /// <param name="ey_start">Ano de início da consulta</param>
    /// <param name="ey_end">Ano de término da consulta</param>
    /// <returns></returns>
    [Get("/alertcity?geocode={geocode}&disease={disease}&format={format}&ew_start={ew_start}&ew_end={ew_end}&ey_start={ey_start}&ey_end={ey_end}")]
    Task<RelatorioAlerta> GetRelatorioAlertaAsync(int geocode, string disease, string format, int ew_start, int ew_end, int ey_start, int ey_end);
}
