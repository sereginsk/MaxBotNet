// СЂСџвЂњРѓ [InlineKeyboard] - Р СљР С•Р Т‘Р ВµР В»РЎРЉ inline Р С”Р В»Р В°Р Р†Р С‘Р В°РЎвЂљРЎС“РЎР‚РЎвЂ№ Р Р† Max Messenger
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ inline Р С”Р В»Р В°Р Р†Р С‘Р В°РЎвЂљРЎС“РЎР‚РЎС“ РЎРѓ Р С”Р Р…Р С•Р С—Р С”Р В°Р СР С‘
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† Message Р Т‘Р В»РЎРЏ Р С—РЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»Р ВµР Р…Р С‘РЎРЏ inline Р С”Р В»Р В°Р Р†Р С‘Р В°РЎвЂљРЎС“РЎР‚РЎвЂ№

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents an inline keyboard with buttons arranged in rows.
/// </summary>
public class InlineKeyboard
{
    /// <summary>
    /// Gets or sets the buttons arranged in rows.
    /// Each inner array represents a row of buttons.
    /// </summary>
    /// <value>An array of button rows, where each row is an array of buttons.</value>
    [JsonPropertyName("inlineKeyboard")]
    public InlineKeyboardButton[][] Buttons { get; set; } = Array.Empty<InlineKeyboardButton[]>();

    /// <summary>
    /// Initializes a new instance of the <see cref="InlineKeyboard"/> class.
    /// </summary>
    public InlineKeyboard()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InlineKeyboard"/> class with the specified buttons.
    /// </summary>
    /// <param name="buttons">The buttons arranged in rows.</param>
    public InlineKeyboard(InlineKeyboardButton[][] buttons)
    {
        Buttons = buttons ?? throw new ArgumentNullException(nameof(buttons));
    }
}

