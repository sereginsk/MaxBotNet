// 📁 [IBotApi] - Интерфейс для методов работы с ботом
// 🎯 Core function: Определяет контракт для API методов работы с ботом
// 🔗 Key dependencies: Max.Bot.Types
// 💡 Usage: Используется для dependency injection и создания моков в тестах

using Max.Bot.Types;

namespace Max.Bot.Api;

/// <summary>
/// Interface for bot-related API methods.
/// </summary>
public interface IBotApi
{
    /// <summary>
    /// Gets information about the current bot.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the bot user information.</returns>
    /// <exception cref="Max.Bot.Exceptions.MaxApiException">Thrown when the API returns an error response.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxNetworkException">Thrown when a network error occurs.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxUnauthorizedException">Thrown when authentication fails.</exception>
    Task<User> GetMeAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets detailed information about the bot.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the detailed bot information.</returns>
    /// <exception cref="Max.Bot.Exceptions.MaxApiException">Thrown when the API returns an error response.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxNetworkException">Thrown when a network error occurs.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxUnauthorizedException">Thrown when authentication fails.</exception>
    Task<User> GetBotInfoAsync(CancellationToken cancellationToken = default);
}

