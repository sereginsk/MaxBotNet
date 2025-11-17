// СЂСџвЂњРѓ [Response] - Р СљР С•Р Т‘Р ВµР В»РЎРЉ РЎС“РЎРѓР С—Р ВµРЎв‚¬Р Р…Р С•Р С–Р С• Р С•РЎвЂљР Р†Р ВµРЎвЂљР В° Р С•РЎвЂљ Max Bot API
// СЂСџР‹Р‡ Core function: Р С›Р В±Р ВµРЎР‚РЎвЂљР С”Р В° Р Т‘Р В»РЎРЏ РЎС“РЎРѓР С—Р ВµРЎв‚¬Р Р…Р С•Р С–Р С• Р С•РЎвЂљР Р†Р ВµРЎвЂљР В° API РЎРѓ Р Т‘Р В°Р Р…Р Р…РЎвЂ№Р СР С‘
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Т‘Р В»РЎРЏ Р Т‘Р ВµРЎРѓР ВµРЎР‚Р С‘Р В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘ РЎС“РЎРѓР С—Р ВµРЎв‚¬Р Р…РЎвЂ№РЎвЂ¦ Р С•РЎвЂљР Р†Р ВµРЎвЂљР С•Р Р† Р С•РЎвЂљ Max Bot API

using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents a successful API response with data.
/// </summary>
/// <typeparam name="T">The type of the response data.</typeparam>
public class Response<T>
{
    /// <summary>
    /// Gets or sets a value indicating whether the request was successful.
    /// </summary>
    /// <value>True if the request was successful; otherwise, false.</value>
    [JsonPropertyName("ok")]
    public bool Ok { get; set; }

    /// <summary>
    /// Gets or sets the response data.
    /// </summary>
    /// <value>The response data, or null if not available.</value>
    [JsonPropertyName("result")]
    public T? Result { get; set; }
}

/// <summary>
/// Represents a simple API response with success status and optional message.
/// </summary>
public class Response
{
    /// <summary>
    /// Gets or sets a value indicating whether the request was successful.
    /// </summary>
    /// <value>True if the request was successful; otherwise, false.</value>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the response message.
    /// </summary>
    /// <value>The response message, or null if not available.</value>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

