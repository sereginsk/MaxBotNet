// СЂСџвЂњРѓ [UpdateHandlerBase] - Р вЂР В°Р В·Р С•Р Р†РЎвЂ№Р в„– Р С”Р В»Р В°РЎРѓРЎРѓ Р С•Р В±РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂЎР С‘Р С”Р В° Р С•Р В±Р Р…Р С•Р Р†Р В»Р ВµР Р…Р С‘Р в„–
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘Р С•РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ no-op РЎР‚Р ВµР В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘ IUpdateHandler
// СЂСџвЂќвЂ” Key dependencies: System.Threading.Tasks
// СЂСџвЂ™РЋ Usage: Р СњР В°РЎРѓР В»Р ВµР Т‘РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р С—Р С•Р В»РЎРЉР В·Р С•Р Р†Р В°РЎвЂљР ВµР В»Р ВµР С Р Т‘Р В»РЎРЏ Р С—Р ВµРЎР‚Р ВµР С•Р С—РЎР‚Р ВµР Т‘Р ВµР В»Р ВµР Р…Р С‘РЎРЏ Р Р…РЎС“Р В¶Р Р…РЎвЂ№РЎвЂ¦ Р СР ВµРЎвЂљР С•Р Т‘Р С•Р Р†

using System.Threading;
using System.Threading.Tasks;

namespace Max.Bot.Polling;

/// <summary>
/// Convenience base class mirroring Telegram.Bot's <c>IUpdateHandler</c> defaults.
/// </summary>
public abstract class UpdateHandlerBase : IUpdateHandler
{
    /// <inheritdoc />
    public virtual Task HandleUpdateAsync(UpdateContext context, CancellationToken cancellationToken) =>
        Task.CompletedTask;

    /// <inheritdoc />
    public virtual Task HandleMessageAsync(UpdateContext context, CancellationToken cancellationToken) =>
        Task.CompletedTask;

    /// <inheritdoc />
    public virtual Task HandleCallbackQueryAsync(UpdateContext context, CancellationToken cancellationToken) =>
        Task.CompletedTask;

    /// <inheritdoc />
    public virtual Task HandleUnknownUpdateAsync(UpdateContext context, CancellationToken cancellationToken) =>
        Task.CompletedTask;
}




