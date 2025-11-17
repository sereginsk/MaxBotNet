// СЂСџвЂњРѓ [MaxUnauthorizedException] - Р ВРЎРѓР С”Р В»РЎР‹РЎвЂЎР ВµР Р…Р С‘Р Вµ Р Т‘Р В»РЎРЏ Р С•РЎв‚¬Р С‘Р В±Р С•Р С” Р В°Р Р†РЎвЂљР С•РЎР‚Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р С•РЎв‚¬Р С‘Р В±Р С”Р С‘ Р В°Р Р†РЎвЂљР С•РЎР‚Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘ (HTTP 401/403)
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Exceptions
// СЂСџвЂ™РЋ Usage: Р вЂ™РЎвЂ№Р В±РЎР‚Р В°РЎРѓРЎвЂ№Р Р†Р В°Р ВµРЎвЂљРЎРѓРЎРЏ Р С—РЎР‚Р С‘ Р Р…Р ВµР В°Р Р†РЎвЂљР С•РЎР‚Р С‘Р В·Р С•Р Р†Р В°Р Р…Р Р…Р С•Р С Р Т‘Р С•РЎРѓРЎвЂљРЎС“Р С—Р Вµ Р С” API

using System.Net;

namespace Max.Bot.Exceptions;

/// <summary>
/// Exception thrown when authentication or authorization fails (HTTP 401 or 403).
/// </summary>
public class MaxUnauthorizedException : MaxApiException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MaxUnauthorizedException"/> class.
    /// </summary>
    public MaxUnauthorizedException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MaxUnauthorizedException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public MaxUnauthorizedException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MaxUnauthorizedException"/> class with a specified error message and inner exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public MaxUnauthorizedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MaxUnauthorizedException"/> class with a specified error message, error code, and HTTP status code.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="errorCode">The error code from the API response.</param>
    /// <param name="httpStatusCode">The HTTP status code from the API response.</param>
    public MaxUnauthorizedException(string message, string? errorCode, HttpStatusCode? httpStatusCode)
        : base(message, errorCode, httpStatusCode)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MaxUnauthorizedException"/> class with a specified error message, error code, HTTP status code, and inner exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="errorCode">The error code from the API response.</param>
    /// <param name="httpStatusCode">The HTTP status code from the API response.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public MaxUnauthorizedException(string message, string? errorCode, HttpStatusCode? httpStatusCode, Exception innerException)
        : base(message, errorCode, httpStatusCode, innerException)
    {
    }
}

