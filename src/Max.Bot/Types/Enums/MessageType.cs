// 📁 [MessageType] - Тип сообщения в Max Messenger
// 🎯 Core function: Перечисление типов сообщений (text, image, file)
// 🔗 Key dependencies: System.Text.Json.Serialization
// 💡 Usage: Используется в модели Message для определения типа сообщения

using System.Text.Json.Serialization;

namespace Max.Bot.Types.Enums;

/// <summary>
/// Represents the type of a message.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MessageType
{
    /// <summary>
    /// Text message.
    /// </summary>
    Text,

    /// <summary>
    /// Image message.
    /// </summary>
    Image,

    /// <summary>
    /// File message.
    /// </summary>
    File
}

