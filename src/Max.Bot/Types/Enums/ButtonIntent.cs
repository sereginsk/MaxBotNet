using System.Text.Json.Serialization;

namespace Max.Bot.Types.Enums;

/// <summary>
/// Represents the intent/style of a callback button.
/// Affects how the button is displayed by the client.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ButtonIntent
{
    /// <summary>
    /// Default button style.
    /// </summary>
    Default,

    /// <summary>
    /// Positive action style (e.g., confirm, accept).
    /// </summary>
    Positive,

    /// <summary>
    /// Negative action style (e.g., cancel, decline).
    /// </summary>
    Negative
}

