// СЂСџвЂњРѓ [MaxNetworkException] - Р ВРЎРѓР С”Р В»РЎР‹РЎвЂЎР ВµР Р…Р С‘Р Вµ Р Т‘Р В»РЎРЏ РЎРѓР ВµРЎвЂљР ВµР Р†РЎвЂ№РЎвЂ¦ Р С•РЎв‚¬Р С‘Р В±Р С•Р С”
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р С•РЎв‚¬Р С‘Р В±Р С”Р С‘ РЎРѓР ВµРЎвЂљР ВµР Р†Р С•Р С–Р С• РЎС“РЎР‚Р С•Р Р†Р Р…РЎРЏ (timeout, connection errors)
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Exceptions
// СЂСџвЂ™РЋ Usage: Р вЂ™РЎвЂ№Р В±РЎР‚Р В°РЎРѓРЎвЂ№Р Р†Р В°Р ВµРЎвЂљРЎРѓРЎРЏ Р С—РЎР‚Р С‘ РЎРѓР ВµРЎвЂљР ВµР Р†РЎвЂ№РЎвЂ¦ Р С—РЎР‚Р С•Р В±Р В»Р ВµР СР В°РЎвЂ¦ Р С—РЎР‚Р С‘ Р Р†Р В·Р В°Р С‘Р СР С•Р Т‘Р ВµР в„–РЎРѓРЎвЂљР Р†Р С‘Р С‘ РЎРѓ API

using System.Net;

namespace Max.Bot.Exceptions;

/// <summary>
/// Exception thrown when a network error occurs while communicating with the Max Bot API.
/// </summary>
public class MaxNetworkException : MaxApiException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MaxNetworkException"/> class.
    /// </summary>
    public MaxNetworkException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MaxNetworkException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public MaxNetworkException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MaxNetworkException"/> class with a specified error message and inner exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public MaxNetworkException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MaxNetworkException"/> class with a specified error message, error code, and HTTP status code.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="errorCode">The error code from the API response.</param>
    /// <param name="httpStatusCode">The HTTP status code from the API response.</param>
    public MaxNetworkException(string message, string? errorCode, HttpStatusCode? httpStatusCode)
        : base(message, errorCode, httpStatusCode)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MaxNetworkException"/> class with a specified error message, error code, HTTP status code, and inner exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="errorCode">The error code from the API response.</param>
    /// <param name="httpStatusCode">The HTTP status code from the API response.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public MaxNetworkException(string message, string? errorCode, HttpStatusCode? httpStatusCode, Exception innerException)
        : base(message, errorCode, httpStatusCode, innerException)
    {
    }
}

