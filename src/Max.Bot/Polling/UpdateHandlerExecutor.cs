// 📁 [UpdateHandlerExecutor] - Вспомогательный исполнитель обработчиков
// 🎯 Core function: Инкапсулирует вызов IUpdateHandler с таймаутом и логированием
// 🔗 Key dependencies: System.Threading.Tasks, Microsoft.Extensions.Logging, Max.Bot.Api, Max.Bot.Configuration, Max.Bot.Types, Max.Bot.Types.Enums
// 💡 Usage: Используется UpdatePoller и WebhookController для единообразной обработки

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Max.Bot.Api;
using Max.Bot.Configuration;
using Max.Bot.Types;
using Max.Bot.Types.Enums;

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
            await handler.HandleUpdateAsync(context, handlerCts.Token).ConfigureAwait(false);

            switch (update.Type)
            {
                case UpdateType.Message:
                    await handler.HandleMessageAsync(context, handlerCts.Token).ConfigureAwait(false);
                    break;
                case UpdateType.CallbackQuery:
                    await handler.HandleCallbackQueryAsync(context, handlerCts.Token).ConfigureAwait(false);
                    break;
                default:
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


