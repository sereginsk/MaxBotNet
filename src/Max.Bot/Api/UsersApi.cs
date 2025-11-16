// 📁 [UsersApi] - Реализация методов работы с пользователями
// 🎯 Core function: Реализация методов IUsersApi (GetUserAsync)
// 🔗 Key dependencies: Max.Bot.Api, Max.Bot.Configuration, Max.Bot.Networking, Max.Bot.Types
// 💡 Usage: Используется в MaxClient для предоставления методов работы с пользователями

using System.Net.Http;
using Max.Bot.Configuration;
using Max.Bot.Networking;
using Max.Bot.Types;

namespace Max.Bot.Api;

/// <summary>
/// Implementation of user-related API methods.
/// </summary>
internal class UsersApi : BaseApi, IUsersApi
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UsersApi"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for requests.</param>
    /// <param name="options">The bot options containing token and base URL.</param>
    /// <exception cref="ArgumentNullException">Thrown when httpClient or options is null.</exception>
    public UsersApi(IMaxHttpClient httpClient, MaxBotOptions options)
        : base(httpClient, options)
    {
    }

    /// <inheritdoc />
    public async Task<User> GetUserAsync(long userId, CancellationToken cancellationToken = default)
    {
        ValidateUserId(userId);

        var request = CreateRequest(HttpMethod.Get, $"/users/{userId}");
        return await ExecuteRequestAsync<User>(request, cancellationToken).ConfigureAwait(false);
    }
}

