// 📁 [MessagesApi] - Реализация методов работы с сообщениями
// 🎯 Core function: Реализация методов IMessagesApi (SendMessageAsync, GetMessagesAsync)
// 🔗 Key dependencies: Max.Bot.Api, Max.Bot.Configuration, Max.Bot.Networking, Max.Bot.Types
// 💡 Usage: Используется в MaxClient для предоставления методов работы с сообщениями

using System.Net.Http;
using Max.Bot.Configuration;
using Max.Bot.Networking;
using Max.Bot.Types;

namespace Max.Bot.Api;

/// <summary>
/// Implementation of message-related API methods.
/// </summary>
internal class MessagesApi : BaseApi, IMessagesApi
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MessagesApi"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for requests.</param>
    /// <param name="options">The bot options containing token and base URL.</param>
    /// <exception cref="ArgumentNullException">Thrown when httpClient or options is null.</exception>
    public MessagesApi(IMaxHttpClient httpClient, MaxBotOptions options)
        : base(httpClient, options)
    {
    }

    /// <inheritdoc />
    public async Task<Message> SendMessageAsync(long chatId, string text, CancellationToken cancellationToken = default)
    {
        ValidateChatId(chatId);
        ValidateNotEmpty(text, nameof(text));

        var body = new
        {
            chatId,
            text
        };

        var request = CreateRequest(HttpMethod.Post, "/messages", body);
        return await ExecuteRequestAsync<Message>(request, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<Message[]> GetMessagesAsync(long chatId, CancellationToken cancellationToken = default)
    {
        ValidateChatId(chatId);

        var queryParams = new Dictionary<string, string?>
        {
            { "chatId", chatId.ToString() }
        };

        var request = CreateRequest(HttpMethod.Get, "/messages", null, queryParams);
        return await ExecuteRequestAsync<Message[]>(request, cancellationToken).ConfigureAwait(false);
    }
}

