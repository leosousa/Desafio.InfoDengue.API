using FluentValidation;
using InfoDengue.Dominio.Contratos.Repositorios;
using InfoDengue.Dominio.Contratos.Servicos.Usuario;
using InfoDengue.Dominio.Recursos;

namespace InfoDengue.Dominio.Servicos.Usuario;

public class ServicoCadastroUsuario : ServicoDominio, IServicoCadastroUsuario
{
    private readonly IRepositorioUsuario _repositorio;
    private readonly IValidator<Entidades.Usuario> _validator;

    public ServicoCadastroUsuario(
        IRepositorioUsuario repositorio,
        IValidator<Entidades.Usuario> validator)
    {
        _repositorio = repositorio;
        _validator = validator;
    }

    public async Task<Entidades.Usuario?> CadastrarAsync(Entidades.Usuario usuario, CancellationToken cancellationToken)
    {
        if (usuario is null)
        {
            AddResultadoAcao(Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);
            AddNotification(nameof(Entidades.Usuario), Mensagens.UsuarioNaoInformado);

            return await Task.FromResult<Entidades.Usuario?>(null);
        }

        var validationResult = await _validator.ValidateAsync(usuario);

        if (!validationResult.IsValid)
        {
            AddResultadoAcao(Enumeracoes.EResultadoAcaoServico.ParametrosInvalidos);
            AddNotifications(validationResult);

            return await Task.FromResult<Entidades.Usuario?>(null);
        }

        var usuarioCadastrado = await _repositorio.CadastrarAsync(usuario);

        if (usuarioCadastrado is null)
        {
            AddResultadoAcao(Enumeracoes.EResultadoAcaoServico.Erro);
            AddNotification(nameof(Entidades.Usuario), Mensagens.OcorreuUmErroAoCadastrarUsuario);

            return await Task.FromResult<Entidades.Usuario?>(null);
        }

        AddResultadoAcao(Enumeracoes.EResultadoAcaoServico.Suceso);

        return await Task.FromResult(usuarioCadastrado);
    }
}