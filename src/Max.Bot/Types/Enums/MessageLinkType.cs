using System.Text.Json.Serialization;

namespace Max.Bot.Types.Enums;

/// <summary>
/// Specifies the type of message link.
/// </summary>
public enum MessageLinkType
{
    /// <summary>
    /// Forward message link type.
    /// </summary>
    [JsonPropertyName("forward")]
    Forward,

    /// <summary>
    /// Reply message link type.
    /// </summary>
    [JsonPropertyName("reply")]
    Reply
}

