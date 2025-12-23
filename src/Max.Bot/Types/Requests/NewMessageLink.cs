using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Max.Bot.Types.Enums;

namespace Max.Bot.Types.Requests;

/// <summary>
/// Represents a link to a message for forwarding or replying.
/// </summary>
public class NewMessageLink
{
    /// <summary>
    /// Gets or sets the type of message link (forward or reply).
    /// </summary>
    /// <value>The type of message link.</value>
    [Required(ErrorMessage = "Message link type is required.")]
    [JsonPropertyName("type")]
    public MessageLinkType Type { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the message to link to.
    /// </summary>
    /// <value>The unique identifier of the message.</value>
    [Required(ErrorMessage = "Message ID is required.")]
    [StringLength(256, ErrorMessage = "Message ID must not exceed 256 characters.")]
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unique identifier of the chat containing the message.
    /// Positive values represent personal chats, negative values represent group chats.
    /// </summary>
    /// <value>The unique identifier of the chat, or null if not specified.</value>
    [JsonPropertyName("chat_id")]
    public long? ChatId { get; set; }
}

