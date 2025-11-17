// 📁 [MessageResponse] - Response wrapper for POST /messages endpoint
// 🎯 Core function: Wrapper for message response from POST /messages
// 🔗 Key dependencies: System.Text.Json.Serialization, Max.Bot.Types
// 💡 Usage: Used to deserialize POST /messages response which returns {"message":{...}}

using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents the response from POST /messages endpoint.
/// </summary>
/// <remarks>
/// POST /messages returns {"message":{...}}, not {"ok":true,"result":{...}}
/// </remarks>
public class MessageResponse
{
    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    /// <value>The message.</value>
    [JsonPropertyName("message")]
    public Message? Message { get; set; }
}

