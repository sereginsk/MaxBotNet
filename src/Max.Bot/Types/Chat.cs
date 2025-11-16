// 📁 [Chat] - Модель чата Max Messenger
// 🎯 Core function: Представляет информацию о чате
// 🔗 Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations, Max.Bot.Types.Enums
// 💡 Usage: Используется в Message для представления чата, в котором было отправлено сообщение

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Max.Bot.Types.Enums;

namespace Max.Bot.Types;

/// <summary>
/// Represents a Max Messenger chat.
/// </summary>
public class Chat
{
    /// <summary>
    /// Gets or sets the unique identifier of the chat.
    /// </summary>
    /// <value>The unique identifier of the chat.</value>
    [Range(1, long.MaxValue, ErrorMessage = "Chat ID must be greater than zero.")]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the chat.
    /// </summary>
    /// <value>The type of the chat (private, group, or channel).</value>
    [JsonPropertyName("type")]
    public ChatType Type { get; set; }

    /// <summary>
    /// Gets or sets the title of the chat (for groups and channels).
    /// </summary>
    /// <value>The title of the chat, or null if not available.</value>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the username of the chat (for private chats and channels).
    /// </summary>
    /// <value>The username of the chat, or null if not available.</value>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the first name of the chat (for private chats).
    /// </summary>
    /// <value>The first name of the chat, or null if not available.</value>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the chat (for private chats).
    /// </summary>
    /// <value>The last name of the chat, or null if not available.</value>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }
}

