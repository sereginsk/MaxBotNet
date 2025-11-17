// СЂСџвЂњРѓ [IMaxHttpClient] - Р ВР Р…РЎвЂљР ВµРЎР‚РЎвЂћР ВµР в„–РЎРѓ HTTP Р С”Р В»Р С‘Р ВµР Р…РЎвЂљР В°
// СЂСџР‹Р‡ Core function: Р С›Р С—РЎР‚Р ВµР Т‘Р ВµР В»РЎРЏР ВµРЎвЂљ Р С”Р С•Р Р…РЎвЂљРЎР‚Р В°Р С”РЎвЂљ Р Т‘Р В»РЎРЏ HTTP Р С”Р В»Р С‘Р ВµР Р…РЎвЂљР В°, Р С•Р В±Р ВµРЎРѓР С—Р ВµРЎвЂЎР С‘Р Р†Р В°РЎРЏ РЎвЂљР ВµРЎРѓРЎвЂљР С‘РЎР‚РЎС“Р ВµР СР С•РЎРѓРЎвЂљРЎРЉ РЎвЂЎР ВµРЎР‚Р ВµР В· Р СР С•Р С”Р С‘
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Networking
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Т‘Р В»РЎРЏ dependency injection Р С‘ РЎРѓР С•Р В·Р Т‘Р В°Р Р…Р С‘РЎРЏ Р СР С•Р С”Р С•Р Р† Р Р† РЎвЂљР ВµРЎРѓРЎвЂљР В°РЎвЂ¦

namespace Max.Bot.Networking;

/// <summary>
/// Interface for HTTP client that handles communication with the Max Bot API.
/// </summary>
public interface IMaxHttpClient
{
    /// <summary>
    /// Sends an HTTP request and deserializes the response.
    /// </summary>
    /// <typeparam name="TResponse">The type to deserialize the response to.</typeparam>
    /// <param name="request">The API request to send.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the deserialized response.</returns>
    /// <exception cref="Max.Bot.Exceptions.MaxApiException">Thrown when the API returns an error response.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxNetworkException">Thrown when a network error occurs.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxRateLimitException">Thrown when rate limit is exceeded.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxUnauthorizedException">Thrown when authentication or authorization fails.</exception>
    Task<TResponse> SendAsync<TResponse>(MaxApiRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP request without expecting a response body.
    /// </summary>
    /// <param name="request">The API request to send.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="Max.Bot.Exceptions.MaxApiException">Thrown when the API returns an error response.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxNetworkException">Thrown when a network error occurs.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxRateLimitException">Thrown when rate limit is exceeded.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxUnauthorizedException">Thrown when authentication or authorization fails.</exception>
    Task SendAsync(MaxApiRequest request, CancellationToken cancellationToken = default);
}

