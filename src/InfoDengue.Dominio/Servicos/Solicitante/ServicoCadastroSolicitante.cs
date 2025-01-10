using FluentValidation;
using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Contratos.Servicos.Solicitante;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Dominio.Servicos.Solicitante;

public class ServicoCadastroSolicitante : ServicoDominio, IServicoCadastroSolicitante
{
    private readonly IRepositorioSolicitante _repositorio;
    private readonly IValidator<Entidades.Solicitante> _validator;

    public ServicoCadastroSolicitante(
        IRepositorioSolicitante repositorio,
        IValidator<Entidades.Solicitante> validator)
    {
        _repositorio = repositorio;
        _validator = validator;
    }

    public async Task<Entidades.Solicitante?> CadastrarAsync(Entidades.Solicitante usuario, CancellationToken cancellationToken)
    {
        if (usuario is null)
        {
            AddResultadoAcao(Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);
            AddNotification(nameof(Entidades.Solicitante), Mensagens.SolicitanteNaoInformado);

            return await Task.FromResult<Entidades.Solicitante?>(null);
        }

        var validationResult = await _validator.ValidateAsync(usuario);

        if (!validationResult.IsValid)
        {
            AddResultadoAcao(Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);
            AddNotifications(validationResult);

            return await Task.FromResult<Entidades.Solicitante?>(null);
        }

        var usuarioCadastrado = await _repositorio.CadastrarAsync(usuario);

        if (usuarioCadastrado is null)
        {
            AddResultadoAcao(Enumeracoes.EResultadoAcaoServico.Erro);
            AddNotification(nameof(Entidades.Solicitante), Mensagens.OcorreuUmErroAoCadastrarSolicitante);

            return await Task.FromResult<Entidades.Solicitante?>(null);
        }

        AddResultadoAcao(Enumeracoes.EResultadoAcaoServico.Sucesso);

        return await Task.FromResult(usuarioCadastrado);
    }
}