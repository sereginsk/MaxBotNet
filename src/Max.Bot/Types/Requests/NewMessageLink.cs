// СЂСџвЂњРѓ [NewMessageLink] - Р РЋРЎРѓРЎвЂ№Р В»Р С”Р В° Р Р…Р В° РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘Р Вµ Р Т‘Р В»РЎРЏ Р С—Р ВµРЎР‚Р ВµРЎРѓРЎвЂ№Р В»Р С”Р С‘/Р С•РЎвЂљР Р†Р ВµРЎвЂљР В°
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ РЎРѓРЎРѓРЎвЂ№Р В»Р С”РЎС“ Р Р…Р В° РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘Р Вµ Р С—РЎР‚Р С‘ Р С•РЎвЂљР С—РЎР‚Р В°Р Р†Р С”Р Вµ Р Р…Р С•Р Р†Р С•Р С–Р С• РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘РЎРЏ
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† SendMessageRequest Р Т‘Р В»РЎРЏ Р С—Р ВµРЎР‚Р ВµРЎРѓРЎвЂ№Р В»Р С”Р С‘ Р С‘Р В»Р С‘ Р С•РЎвЂљР Р†Р ВµРЎвЂљР В° Р Р…Р В° РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘Р Вµ

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types.Requests;

/// <summary>
/// Represents a link to a message for forwarding or replying.
/// </summary>
public class NewMessageLink
{
    /// <summary>
    /// Gets or sets the unique identifier of the message to link to.
    /// </summary>
    /// <value>The unique identifier of the message.</value>
    [Range(1, long.MaxValue, ErrorMessage = "Message ID must be greater than zero.")]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the chat containing the message.
    /// </summary>
    /// <value>The unique identifier of the chat, or null if not specified.</value>
    [Range(1, long.MaxValue, ErrorMessage = "Chat ID must be greater than zero.")]
    [JsonPropertyName("chatId")]
    public long? ChatId { get; set; }
}

