using InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorMunicipio.BuscarRelatorioPorMunicipio;
using InfoDengue.Aplicacao.Contratos;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Dominio.Contratos.Servicos.Municipio;
using InfoDengue.Dominio.Recursos;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Epidemiologia.ListarTotaisCasosArbovirosePorNomeMunicipio;

public class ListarTotaisCasosArbovirosePorNomeMunicipioQueryHandler :
    IRequestHandler<ListarTotaisCasosArbovirosePorNomeMunicipioQuery, Result<RelatorioEpidemiologicoTotalCommandResult>>
{
    private readonly IServicoBuscaMunicipioPorNome _servicoBuscaMunicipioPorNome;
    private readonly IServicoGeradorRelatorioTotais _servicoGeradorRelatorioTotais;

    public ListarTotaisCasosArbovirosePorNomeMunicipioQueryHandler(IServicoBuscaMunicipioPorNome servicoBuscaMunicipioPorNome, IServicoGeradorRelatorioTotais servicoGeradorRelatorioTotais)
    {
        _servicoBuscaMunicipioPorNome = servicoBuscaMunicipioPorNome;
        _servicoGeradorRelatorioTotais = servicoGeradorRelatorioTotais;
    }

    public async Task<Result<RelatorioEpidemiologicoTotalCommandResult>> Handle(ListarTotaisCasosArbovirosePorNomeMunicipioQuery command, CancellationToken cancellationToken)
    {
        Result<RelatorioEpidemiologicoTotalCommandResult> result = new();

        if (string.IsNullOrWhiteSpace(command.NomeMunicipio))
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorMunicipioCommand.NomeMunicipio), Mensagens.NomeMunicipioNaoInformado);

            return await Task.FromResult(result);
        }

        var municipioEncontrado = await _servicoBuscaMunicipioPorNome.BuscarPorNomeAsync(command.NomeMunicipio, cancellationToken);

        if (municipioEncontrado is null)
        {
            result.AddResultadoAcao(Dominio.Enumeracoes.EResultadoAcaoServico.NaoEncontrado);

            result.AddNotification(nameof(RelatorioEpidemiologicoPorMunicipioCommand.NomeMunicipio), Mensagens.MunicipioNaoEncontrado);

            return await Task.FromResult(result);
        }

        var parametros = new RelatorioEpidemiologicoTotalCommand
        {
            Arbovirose = command.Arbovirose,
            DataInicio = command.DataInicio,
            DataTermino = command.DataTermino,
            CodigoIbge = municipioEncontrado.CodigoIbge,
            Solicitante = new SolicitanteDto
            {
                Cpf = command.Solicitante.Cpf,
                Nome = command.Solicitante.Nome
            }
        };

        return await _servicoGeradorRelatorioTotais.GerarRelatorioEpidemiologicoTotais(parametros, cancellationToken).ConfigureAwait(false);
    }
}