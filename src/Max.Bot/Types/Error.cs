// СЂСџвЂњРѓ [Error] - Р СљР С•Р Т‘Р ВµР В»РЎРЉ Р С•РЎв‚¬Р С‘Р В±Р С”Р С‘ Max Bot API
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р С‘Р Р…РЎвЂћР С•РЎР‚Р СР В°РЎвЂ Р С‘РЎР‹ Р С•Р В± Р С•РЎв‚¬Р С‘Р В±Р С”Р Вµ API
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† ErrorResponse Р Т‘Р В»РЎРЏ Р С—РЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»Р ВµР Р…Р С‘РЎРЏ Р С•РЎв‚¬Р С‘Р В±Р С•Р С” API

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents an API error.
/// </summary>
public class Error
{
    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    /// <value>The error code from the API, or null if not available.</value>
    [StringLength(64, MinimumLength = 1, ErrorMessage = "Error code must be between 1 and 64 characters if provided.")]
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    /// <value>The error message from the API, or null if not available.</value>
    [StringLength(512, MinimumLength = 1, ErrorMessage = "Error message must be between 1 and 512 characters if provided.")]
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets additional error details.
    /// </summary>
    /// <value>Additional error details as key-value pairs, or null if not available.</value>
    [JsonPropertyName("details")]
    public Dictionary<string, object>? Details { get; set; }
}

