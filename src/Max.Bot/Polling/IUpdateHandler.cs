// СЂСџвЂњРѓ [IUpdateHandler] - Р С™Р С•Р Р…РЎвЂљРЎР‚Р В°Р С”РЎвЂљ Р С•Р В±РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂЎР С‘Р С”Р В° Р С•Р В±Р Р…Р С•Р Р†Р В»Р ВµР Р…Р С‘Р в„–
// СЂСџР‹Р‡ Core function: Р С›Р С—РЎР‚Р ВµР Т‘Р ВµР В»РЎРЏР ВµРЎвЂљ async Р СР ВµРЎвЂљР С•Р Т‘РЎвЂ№ Р Т‘Р В»РЎРЏ Р С”Р В°Р В¶Р Т‘Р С•Р С–Р С• UpdateType
// СЂСџвЂќвЂ” Key dependencies: System.Threading, Max.Bot.Types.Enums
// СЂСџвЂ™РЋ Usage: Р В Р ВµР В°Р В»Р С‘Р В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р С—Р С•Р В»РЎРЉР В·Р С•Р Р†Р В°РЎвЂљР ВµР В»Р ВµР С Р Т‘Р В»РЎРЏ Р С•Р В±РЎР‚Р В°Р В±Р С•РЎвЂљР С”Р С‘ РЎРѓР С•Р В±РЎвЂ№РЎвЂљР С‘Р в„– Р В±Р С•РЎвЂљР В°

using System.Threading;
using System.Threading.Tasks;
using Max.Bot.Types.Enums;

namespace Max.Bot.Polling;

/// <summary>
/// Contract for handling updates emitted by the poller or webhook pipelines.
/// </summary>
public interface IUpdateHandler
{
    /// <summary>
    /// Entry point invoked for every update before type-specific dispatch occurs.
    /// </summary>
    Task HandleUpdateAsync(UpdateContext context, CancellationToken cancellationToken);

    /// <summary>
    /// Invoked for <see cref="UpdateType.Message"/> events.
    /// </summary>
    Task HandleMessageAsync(UpdateContext context, CancellationToken cancellationToken);

    /// <summary>
    /// Invoked for <see cref="UpdateType.CallbackQuery"/> events.
    /// </summary>
    Task HandleCallbackQueryAsync(UpdateContext context, CancellationToken cancellationToken);

    /// <summary>
    /// Invoked when an update type is not explicitly handled.
    /// </summary>
    Task HandleUnknownUpdateAsync(UpdateContext context, CancellationToken cancellationToken);
}




