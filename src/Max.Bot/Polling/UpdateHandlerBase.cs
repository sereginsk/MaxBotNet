// 📁 [UpdateHandlerBase] - Базовый класс обработчика обновлений
// 🎯 Core function: Предоставляет no-op реализации IUpdateHandler
// 🔗 Key dependencies: System.Threading.Tasks
// 💡 Usage: Наследуется пользователем для переопределения нужных методов

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


