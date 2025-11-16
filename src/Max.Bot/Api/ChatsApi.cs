// 📁 [ChatsApi] - Реализация методов работы с чатами
// 🎯 Core function: Реализация методов IChatsApi (GetChatAsync, GetChatsAsync)
// 🔗 Key dependencies: Max.Bot.Api, Max.Bot.Configuration, Max.Bot.Networking, Max.Bot.Types
// 💡 Usage: Используется в MaxClient для предоставления методов работы с чатами

using System.Net.Http;
using Max.Bot.Configuration;
using Max.Bot.Networking;
using Max.Bot.Types;

namespace Max.Bot.Api;

/// <summary>
/// Implementation of chat-related API methods.
/// </summary>
internal class ChatsApi : BaseApi, IChatsApi
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChatsApi"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for requests.</param>
    /// <param name="options">The bot options containing token and base URL.</param>
    /// <exception cref="ArgumentNullException">Thrown when httpClient or options is null.</exception>
    public ChatsApi(IMaxHttpClient httpClient, MaxBotOptions options)
        : base(httpClient, options)
    {
    }

    /// <inheritdoc />
    public async Task<Chat> GetChatAsync(long chatId, CancellationToken cancellationToken = default)
    {
        ValidateChatId(chatId);

        var request = CreateRequest(HttpMethod.Get, $"/chats/{chatId}");
        return await ExecuteRequestAsync<Chat>(request, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<Chat[]> GetChatsAsync(CancellationToken cancellationToken = default)
    {
        var request = CreateRequest(HttpMethod.Get, "/chats");
        return await ExecuteRequestAsync<Chat[]>(request, cancellationToken).ConfigureAwait(false);
    }
}

