// СЂСџвЂњРѓ [IUsersApi] - Р ВР Р…РЎвЂљР ВµРЎР‚РЎвЂћР ВµР в„–РЎРѓ Р Т‘Р В»РЎРЏ Р СР ВµРЎвЂљР С•Р Т‘Р С•Р Р† РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ РЎРѓ Р С—Р С•Р В»РЎРЉР В·Р С•Р Р†Р В°РЎвЂљР ВµР В»РЎРЏР СР С‘
// СЂСџР‹Р‡ Core function: Р С›Р С—РЎР‚Р ВµР Т‘Р ВµР В»РЎРЏР ВµРЎвЂљ Р С”Р С•Р Р…РЎвЂљРЎР‚Р В°Р С”РЎвЂљ Р Т‘Р В»РЎРЏ API Р СР ВµРЎвЂљР С•Р Т‘Р С•Р Р† РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ РЎРѓ Р С—Р С•Р В»РЎРЉР В·Р С•Р Р†Р В°РЎвЂљР ВµР В»РЎРЏР СР С‘
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Types
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Т‘Р В»РЎРЏ dependency injection Р С‘ РЎРѓР С•Р В·Р Т‘Р В°Р Р…Р С‘РЎРЏ Р СР С•Р С”Р С•Р Р† Р Р† РЎвЂљР ВµРЎРѓРЎвЂљР В°РЎвЂ¦

using Max.Bot.Types;

namespace Max.Bot.Api;

/// <summary>
/// Interface for user-related API methods.
/// </summary>
public interface IUsersApi
{
    /// <summary>
    /// Gets information about a user by their identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user information.</returns>
    /// <exception cref="ArgumentException">Thrown when userId is less than or equal to zero.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxApiException">Thrown when the API returns an error response.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxNetworkException">Thrown when a network error occurs.</exception>
    /// <exception cref="Max.Bot.Exceptions.MaxUnauthorizedException">Thrown when authentication fails.</exception>
    Task<User> GetUserAsync(long userId, CancellationToken cancellationToken = default);
}

