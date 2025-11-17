// СЂСџвЂњРѓ [InlineKeyboardButton] - Р СљР С•Р Т‘Р ВµР В»РЎРЉ Р С”Р Р…Р С•Р С—Р С”Р С‘ inline Р С”Р В»Р В°Р Р†Р С‘Р В°РЎвЂљРЎС“РЎР‚РЎвЂ№ Р Р† Max Messenger
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р С”Р Р…Р С•Р С—Р С”РЎС“ inline Р С”Р В»Р В°Р Р†Р С‘Р В°РЎвЂљРЎС“РЎР‚РЎвЂ№
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† InlineKeyboard Р Т‘Р В»РЎРЏ РЎРѓР С•Р В·Р Т‘Р В°Р Р…Р С‘РЎРЏ Р С”Р Р…Р С•Р С—Р С•Р С”

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents a button in an inline keyboard.
/// </summary>
public class InlineKeyboardButton
{
    /// <summary>
    /// Gets or sets the text displayed on the button.
    /// </summary>
    /// <value>The text displayed on the button.</value>
    [Required(ErrorMessage = "Text is required.")]
    [StringLength(64, MinimumLength = 1, ErrorMessage = "Text must be between 1 and 64 characters.")]
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the callback data sent when the button is pressed.
    /// </summary>
    /// <value>The callback data, or null if not available.</value>
    [StringLength(64, ErrorMessage = "Callback data must not exceed 64 characters.")]
    [JsonPropertyName("callbackData")]
    public string? CallbackData { get; set; }

    /// <summary>
    /// Gets or sets the URL to open when the button is pressed.
    /// </summary>
    /// <value>The URL, or null if not available.</value>
    [Url(ErrorMessage = "URL must be a valid URL if provided.")]
    [StringLength(2048, ErrorMessage = "URL must not exceed 2048 characters.")]
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}

