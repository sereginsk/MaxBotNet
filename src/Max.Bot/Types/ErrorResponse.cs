// СЂСџвЂњРѓ [ErrorResponse] - Р СљР С•Р Т‘Р ВµР В»РЎРЉ Р С•РЎвЂљР Р†Р ВµРЎвЂљР В° РЎРѓ Р С•РЎв‚¬Р С‘Р В±Р С”Р С•Р в„– Р С•РЎвЂљ Max Bot API
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р С•РЎвЂљР Р†Р ВµРЎвЂљ API РЎРѓ Р С•РЎв‚¬Р С‘Р В±Р С”Р С•Р в„–
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, Max.Bot.Types
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Т‘Р В»РЎРЏ Р Т‘Р ВµРЎРѓР ВµРЎР‚Р С‘Р В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘ Р С•РЎвЂљР Р†Р ВµРЎвЂљР С•Р Р† РЎРѓ Р С•РЎв‚¬Р С‘Р В±Р С”Р В°Р СР С‘ Р С•РЎвЂљ Max Bot API

using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents an API error response.
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Gets or sets a value indicating whether the request was successful (always false for errors).
    /// </summary>
    /// <value>False for error responses.</value>
    [JsonPropertyName("ok")]
    public bool Ok { get; set; }

    /// <summary>
    /// Gets or sets the error information.
    /// </summary>
    /// <value>The error information, or null if not available.</value>
    [JsonPropertyName("error")]
    public Error? Error { get; set; }
}

