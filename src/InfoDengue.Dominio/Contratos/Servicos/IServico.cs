using Flunt.Notifications;
using InfoDengue.Dominio.Enumeracoes;

namespace InfoDengue.Dominio.Contratos.Servicos;

public interface IServico
{
    EResultadoAcaoServico ResultadoAcao { get; }

    bool IsValid { get; }

    IReadOnlyCollection<Notification> Notifications { get; }
}