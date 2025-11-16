// 📁 [Message] - Модель сообщения Max Messenger
// 🎯 Core function: Представляет информацию о сообщении
// 🔗 Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations, Max.Bot.Types, Max.Bot.Types.Enums, Max.Bot.Types.Converters
// 💡 Usage: Используется в Update для представления сообщения

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Max.Bot.Types.Enums;
using Max.Bot.Types.Converters;

namespace Max.Bot.Types;

/// <summary>
/// Represents a Max Messenger message.
/// </summary>
public class Message
{
    /// <summary>
    /// Gets or sets the unique identifier of the message.
    /// </summary>
    /// <value>The unique identifier of the message.</value>
    [Range(1, long.MaxValue, ErrorMessage = "Message ID must be greater than zero.")]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the chat where the message was sent.
    /// </summary>
    /// <value>The chat where the message was sent, or null if not available.</value>
    [JsonPropertyName("chat")]
    public Chat? Chat { get; set; }

    /// <summary>
    /// Gets or sets the user who sent the message.
    /// </summary>
    /// <value>The user who sent the message, or null if not available.</value>
    [JsonPropertyName("from")]
    public User? From { get; set; }

    /// <summary>
    /// Gets or sets the text content of the message.
    /// </summary>
    /// <value>The text content of the message, or null if not available.</value>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// Gets or sets the date when the message was sent (Unix timestamp).
    /// </summary>
    /// <value>The date when the message was sent.</value>
    [JsonPropertyName("date")]
    [JsonConverter(typeof(UnixTimestampJsonConverter))]
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the type of the message.
    /// </summary>
    /// <value>The type of the message (text, image, or file).</value>
    [JsonPropertyName("type")]
    public MessageType? Type { get; set; }
}

