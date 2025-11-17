// 📁 [IUpdatePipeline] - Контракт обработки webhook и polling обновлений
// 🎯 Core function: Унифицирует API обработки обновлений для контроллера и poller
// 🔗 Key dependencies: System.Threading.Tasks, Max.Bot.Types
// 💡 Usage: Реализуется MaxClient для проксирования обновлений в IUpdateHandler

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


