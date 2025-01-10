using AutoMapper;
using InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorMunicipio.BuscarRelatorioPorMunicipio;
using InfoDengue.Aplicacao.Contratos;
using InfoDengue.Aplicacao.DTOs;
using InfoDengue.Dominio.Contratos.Servicos.Municipio;
using InfoDengue.Dominio.Recursos;
using MediatR;

namespace InfoDengue.Aplicacao.CasosUso.Epidemiologia.GerarRelatorioEpidemiologicoPorMunicipio;

public class RelatorioEpidemiologicoPorMunicipioCommandHandler :
    IRequestHandler<RelatorioEpidemiologicoPorMunicipioCommand, Result<RelatorioEpidemiologicoCommandResult>>
{
    private readonly IMapper _mapper;
    private readonly IServicoBuscaMunicipioPorNome _servicoBuscaMunicipioPorNome;
    private readonly IServicoGeradorRelatorioEpidemiologico _servicoGeradorRelatorioEpidemiologico;

    public RelatorioEpidemiologicoPorMunicipioCommandHandler(
        IMapper mapper,
        IServicoBuscaMunicipioPorNome servicoBuscaMunicipioPorNome,
        IServicoGeradorRelatorioEpidemiologico servicoGeradorRelatorioEpidemiologico)
    {
        _mapper = mapper;
        _servicoBuscaMunicipioPorNome = servicoBuscaMunicipioPorNome;
        _servicoGeradorRelatorioEpidemiologico = servicoGeradorRelatorioEpidemiologico;
    }

    public async Task<Result<RelatorioEpidemiologicoCommandResult>> Handle(RelatorioEpidemiologicoPorMunicipioCommand command, CancellationToken cancellationToken)
    {
        Result<RelatorioEpidemiologicoCommandResult> result = new();

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

        var parametros = new RelatorioEpidemiologicoCommand
        {
            Arbovirose = command.Arbovirose,
            CodigoIbge = municipioEncontrado.CodigoIbge,
            DataInicio = command.DataInicio,
            DataTermino = command.DataTermino,
            Solicitante = new SolicitanteDto
            {
                Nome = command.Solicitante.Nome,
                Cpf = command.Solicitante.Cpf
            }
        };

        result = await _servicoGeradorRelatorioEpidemiologico.GerarRelatorioEpidemiologico(parametros, cancellationToken);

        return await Task.FromResult(result);
    }
}
