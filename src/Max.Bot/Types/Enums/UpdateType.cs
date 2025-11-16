// 📁 [UpdateType] - Тип обновления в Max Messenger
// 🎯 Core function: Перечисление типов обновлений (message, callback_query)
// 🔗 Key dependencies: System.Text.Json.Serialization
// 💡 Usage: Используется в модели Update для определения типа обновления

using System.Text.Json.Serialization;

namespace Max.Bot.Types.Enums;

/// <summary>
/// Represents the type of an update.
/// </summary>
public enum UpdateType
{
    /// <summary>
    /// New message update.
    /// </summary>
    Message,

    /// <summary>
    /// Callback query update.
    /// </summary>
    CallbackQuery
}

