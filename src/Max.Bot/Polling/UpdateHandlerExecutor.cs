// СЂСџвЂњРѓ [UpdateHandlerExecutor] - Р вЂ™РЎРѓР С—Р С•Р СР С•Р С–Р В°РЎвЂљР ВµР В»РЎРЉР Р…РЎвЂ№Р в„– Р С‘РЎРѓР С—Р С•Р В»Р Р…Р С‘РЎвЂљР ВµР В»РЎРЉ Р С•Р В±РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂЎР С‘Р С”Р С•Р Р†
// СЂСџР‹Р‡ Core function: Р ВР Р…Р С”Р В°Р С—РЎРѓРЎС“Р В»Р С‘РЎР‚РЎС“Р ВµРЎвЂљ Р Р†РЎвЂ№Р В·Р С•Р Р† IUpdateHandler РЎРѓ РЎвЂљР В°Р в„–Р СР В°РЎС“РЎвЂљР С•Р С Р С‘ Р В»Р С•Р С–Р С‘РЎР‚Р С•Р Р†Р В°Р Р…Р С‘Р ВµР С
// СЂСџвЂќвЂ” Key dependencies: System.Threading.Tasks, Microsoft.Extensions.Logging, Max.Bot.Api, Max.Bot.Configuration, Max.Bot.Types, Max.Bot.Types.Enums
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ UpdatePoller Р С‘ WebhookController Р Т‘Р В»РЎРЏ Р ВµР Т‘Р С‘Р Р…Р С•Р С•Р В±РЎР‚Р В°Р В·Р Р…Р С•Р в„– Р С•Р В±РЎР‚Р В°Р В±Р С•РЎвЂљР С”Р С‘

using System;
using System.Threading;
using System.Threading.Tasks;
using Max.Bot.Api;
using Max.Bot.Configuration;
using Max.Bot.Types;
using Max.Bot.Types.Enums;
using Microsoft.Extensions.Logging;

namespace Max.Bot.Polling;

internal static class UpdateHandlerExecutor
{
    public static async Task ExecuteAsync(
        Update update,
        IUpdateHandler handler,
        MaxBotOptions options,
        IMaxBotApi api,
        ILogger? logger,
        IServiceProvider? services,
        CancellationToken cancellationToken)
    {
        using var handlerCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        if (options.Handling.HandlerTimeout > TimeSpan.Zero)
        {
            handlerCts.CancelAfter(options.Handling.HandlerTimeout);
        }

        var context = new UpdateContext(update, api, options, logger, services);

        try
        {
            // * For type-specific updates (Message, CallbackQuery), skip HandleUpdateAsync to avoid double processing
            // This prevents calling both HandleUpdateAsync and HandleMessageAsync/HandleCallbackQueryAsync
            // User should implement either HandleUpdateAsync (for all) or HandleMessageAsync/HandleCallbackQueryAsync (for specific)
            switch (update.Type)
            {
                case UpdateType.Message:
                    // * Skip HandleUpdateAsync for messages - only call HandleMessageAsync to avoid double processing
                    await handler.HandleMessageAsync(context, handlerCts.Token).ConfigureAwait(false);
                    break;
                case UpdateType.CallbackQuery:
                    // * Skip HandleUpdateAsync for callbacks - only call HandleCallbackQueryAsync to avoid double processing
                    await handler.HandleCallbackQueryAsync(context, handlerCts.Token).ConfigureAwait(false);
                    break;
                default:
                    // * For unknown types, call HandleUpdateAsync first, then HandleUnknownUpdateAsync
                    await handler.HandleUpdateAsync(context, handlerCts.Token).ConfigureAwait(false);
                    await handler.HandleUnknownUpdateAsync(context, handlerCts.Token).ConfigureAwait(false);
                    break;
            }
        }
        catch (OperationCanceledException ex) when (!cancellationToken.IsCancellationRequested && handlerCts.IsCancellationRequested)
        {
            if (options.Handling.PropagateHandlerExceptions)
            {
                throw;
            }

            logger?.LogWarning(ex, "Update handler timed out after {Timeout}. UpdateId={UpdateId}", options.Handling.HandlerTimeout, update.UpdateId);
        }
        catch (Exception ex)
        {
            if (options.Handling.PropagateHandlerExceptions)
            {
                throw;
            }

            logger?.LogError(ex, "Update handler threw an exception for update {UpdateId}.", update.UpdateId);
        }
    }
}




