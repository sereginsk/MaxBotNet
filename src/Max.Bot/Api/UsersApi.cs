// СЂСџвЂњРѓ [UsersApi] - Р В Р ВµР В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘РЎРЏ Р СР ВµРЎвЂљР С•Р Т‘Р С•Р Р† РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ РЎРѓ Р С—Р С•Р В»РЎРЉР В·Р С•Р Р†Р В°РЎвЂљР ВµР В»РЎРЏР СР С‘
// СЂСџР‹Р‡ Core function: Р В Р ВµР В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘РЎРЏ Р СР ВµРЎвЂљР С•Р Т‘Р С•Р Р† IUsersApi (GetUserAsync)
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Api, Max.Bot.Configuration, Max.Bot.Networking, Max.Bot.Types
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† MaxClient Р Т‘Р В»РЎРЏ Р С—РЎР‚Р ВµР Т‘Р С•РЎРѓРЎвЂљР В°Р Р†Р В»Р ВµР Р…Р С‘РЎРЏ Р СР ВµРЎвЂљР С•Р Т‘Р С•Р Р† РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ РЎРѓ Р С—Р С•Р В»РЎРЉР В·Р С•Р Р†Р В°РЎвЂљР ВµР В»РЎРЏР СР С‘

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

