// СЂСџвЂњРѓ [IUpdatePipeline] - Р С™Р С•Р Р…РЎвЂљРЎР‚Р В°Р С”РЎвЂљ Р С•Р В±РЎР‚Р В°Р В±Р С•РЎвЂљР С”Р С‘ webhook Р С‘ polling Р С•Р В±Р Р…Р С•Р Р†Р В»Р ВµР Р…Р С‘Р в„–
// СЂСџР‹Р‡ Core function: Р Р€Р Р…Р С‘РЎвЂћР С‘РЎвЂ Р С‘РЎР‚РЎС“Р ВµРЎвЂљ API Р С•Р В±РЎР‚Р В°Р В±Р С•РЎвЂљР С”Р С‘ Р С•Р В±Р Р…Р С•Р Р†Р В»Р ВµР Р…Р С‘Р в„– Р Т‘Р В»РЎРЏ Р С”Р С•Р Р…РЎвЂљРЎР‚Р С•Р В»Р В»Р ВµРЎР‚Р В° Р С‘ poller
// СЂСџвЂќвЂ” Key dependencies: System.Threading.Tasks, Max.Bot.Types
// СЂСџвЂ™РЋ Usage: Р В Р ВµР В°Р В»Р С‘Р В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ MaxClient Р Т‘Р В»РЎРЏ Р С—РЎР‚Р С•Р С”РЎРѓР С‘РЎР‚Р С•Р Р†Р В°Р Р…Р С‘РЎРЏ Р С•Р В±Р Р…Р С•Р Р†Р В»Р ВµР Р…Р С‘Р в„– Р Р† IUpdateHandler

using System;
using System.Threading;
using System.Threading.Tasks;
using Max.Bot.Types;

namespace Max.Bot.Polling;

/// <summary>
/// Defines operations required to dispatch updates to application handlers.
/// </summary>
public interface IUpdatePipeline
{
    /// <summary>
    /// Processes a webhook update payload.
    /// </summary>
    Task ProcessWebhookAsync(Update update, IUpdateHandler handler, IServiceProvider? services = null, CancellationToken cancellationToken = default);
}




