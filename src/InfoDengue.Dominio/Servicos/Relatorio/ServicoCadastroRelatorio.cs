using FluentValidation;
using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Contratos.Servicos.Relatorio;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Dominio.Servicos.Relatorio;

public class ServicoCadastroRelatorio : ServicoDominio, IServicoCadastroRelatorio
{
    private readonly IRepositorioRelatorio _repositorio;
    private readonly IValidator<Entidades.Relatorio> _validator;

    public ServicoCadastroRelatorio(
        IRepositorioRelatorio repositorio,
        IValidator<Entidades.Relatorio> validator)
    {
        _repositorio = repositorio;
        _validator = validator;
    }

    public async Task<Entidades.Relatorio?> CadastrarAsync(Entidades.Relatorio relatorio, CancellationToken cancellationToken)
    {
        if (relatorio is null)
        {
            AddResultadoAcao(Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);
            AddNotification(nameof(Entidades.Relatorio), Mensagens.RelatorioNaoInformado);

            return await Task.FromResult<Entidades.Relatorio?>(null);
        }

        var validationResult = await _validator.ValidateAsync(relatorio);

        if (!validationResult.IsValid)
        {
            AddResultadoAcao(Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);
            AddNotifications(validationResult);

            return await Task.FromResult<Entidades.Relatorio?>(null);
        }

        var relatorioCadastrado = await _repositorio.CadastrarAsync(relatorio);

        if (relatorioCadastrado is null)
        {
            AddResultadoAcao(Enumeracoes.EResultadoAcaoServico.Erro);
            AddNotification(nameof(Entidades.Relatorio), Mensagens.OcorreuUmErroAoCadastrarRelatorio);

            return await Task.FromResult<Entidades.Relatorio?>(null);
        }

        AddResultadoAcao(Enumeracoes.EResultadoAcaoServico.Sucesso);

        return await Task.FromResult(relatorioCadastrado);
    }
}