// 📁 [IMessagesApi] - Интерфейс для методов работы с сообщениями
// 🎯 Core function: Определяет контракт для API методов работы с сообщениями
// 🔗 Key dependencies: Max.Bot.Types
// 💡 Usage: Используется для dependency injection и создания моков в тестах

using Max.Bot.Types;

namespace Max.Bot.Api;

/// <summary>
/// Interface for message-related API methods.
/// </summary>
public interface IMessagesApi
{
    /// <summary>
    /// Sends a text message to the specified chat.
    /// </summary>
    /// <param name="chatId">The unique identifier of the chat.</param>
    /// <param name="text">The text of the message to send.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the sent message.</returns>
    /// <exception cref="ArgumentException">Thrown when chatId is less than or equal to zero, or text is null or empty.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxApiException">Thrown when the API returns an error response.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxNetworkException">Thrown when a network error occurs.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxUnauthorizedException">Thrown when authentication fails.</exception>
    Task<Message> SendMessageAsync(long chatId, string text, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of messages from the specified chat.
    /// </summary>
    /// <param name="chatId">The unique identifier of the chat.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an array of messages.</returns>
    /// <exception cref="ArgumentException">Thrown when chatId is less than or equal to zero.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxApiException">Thrown when the API returns an error response.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxNetworkException">Thrown when a network error occurs.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxUnauthorizedException">Thrown when authentication fails.</exception>
    Task<Message[]> GetMessagesAsync(long chatId, CancellationToken cancellationToken = default);
}

