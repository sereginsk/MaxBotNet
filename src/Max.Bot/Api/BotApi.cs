// СЂСџвЂњРѓ [BotApi] - Р В Р ВµР В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘РЎРЏ Р СР ВµРЎвЂљР С•Р Т‘Р С•Р Р† РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ РЎРѓ Р В±Р С•РЎвЂљР С•Р С
// СЂСџР‹Р‡ Core function: Р В Р ВµР В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘РЎРЏ Р СР ВµРЎвЂљР С•Р Т‘Р С•Р Р† IBotApi (GetMeAsync, GetBotInfoAsync)
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Api, Max.Bot.Configuration, Max.Bot.Networking, Max.Bot.Types
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† MaxClient Р Т‘Р В»РЎРЏ Р С—РЎР‚Р ВµР Т‘Р С•РЎРѓРЎвЂљР В°Р Р†Р В»Р ВµР Р…Р С‘РЎРЏ Р СР ВµРЎвЂљР С•Р Т‘Р С•Р Р† РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ РЎРѓ Р В±Р С•РЎвЂљР С•Р С

using Max.Bot.Configuration;
using Max.Bot.Networking;
using Max.Bot.Types;

namespace Max.Bot.Api;

/// <summary>
/// Implementation of bot-related API methods.
/// </summary>
internal class BotApi : BaseApi, IBotApi
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BotApi"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for requests.</param>
    /// <param name="options">The bot options containing token and base URL.</param>
    /// <exception cref="ArgumentNullException">Thrown when httpClient or options is null.</exception>
    public BotApi(IMaxHttpClient httpClient, MaxBotOptions options)
        : base(httpClient, options)
    {
    }

    /// <inheritdoc />
    public async Task<User> GetMeAsync(CancellationToken cancellationToken = default)
    {
        var request = CreateRequest(HttpMethod.Get, "/me");
        return await ExecuteRequestAsync<User>(request, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<User> GetBotInfoAsync(CancellationToken cancellationToken = default)
    {
        var request = CreateRequest(HttpMethod.Get, "/bot/info");
        return await ExecuteRequestAsync<User>(request, cancellationToken).ConfigureAwait(false);
    }
}

