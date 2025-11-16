// 📁 [IChatsApi] - Интерфейс для методов работы с чатами
// 🎯 Core function: Определяет контракт для API методов работы с чатами
// 🔗 Key dependencies: Max.Bot.Types
// 💡 Usage: Используется для dependency injection и создания моков в тестах

using Max.Bot.Types;

namespace Max.Bot.Api;

/// <summary>
/// Interface for chat-related API methods.
/// </summary>
public interface IChatsApi
{
    /// <summary>
    /// Gets information about a chat by its identifier.
    /// </summary>
    /// <param name="chatId">The unique identifier of the chat.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the chat information.</returns>
    /// <exception cref="ArgumentException">Thrown when chatId is less than or equal to zero.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxApiException">Thrown when the API returns an error response.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxNetworkException">Thrown when a network error occurs.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxUnauthorizedException">Thrown when authentication fails.</exception>
    Task<Chat> GetChatAsync(long chatId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of all chats for the bot.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an array of chats.</returns>
    /// <exception cref="Max.Bot.Exceptions.MaxApiException">Thrown when the API returns an error response.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxNetworkException">Thrown when a network error occurs.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxUnauthorizedException">Thrown when authentication fails.</exception>
    Task<Chat[]> GetChatsAsync(CancellationToken cancellationToken = default);
}

