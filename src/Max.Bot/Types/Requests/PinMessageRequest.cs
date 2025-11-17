// СЂСџвЂњРѓ [PinMessageRequest] - Р вЂ”Р В°Р С—РЎР‚Р С•РЎРѓ Р Р…Р В° Р В·Р В°Р С”РЎР‚Р ВµР С—Р В»Р ВµР Р…Р С‘Р Вµ РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘РЎРЏ
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р В·Р В°Р С—РЎР‚Р С•РЎРѓ Р Т‘Р В»РЎРЏ Р В·Р В°Р С”РЎР‚Р ВµР С—Р В»Р ВµР Р…Р С‘РЎРЏ РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘РЎРЏ Р Р† РЎвЂЎР В°РЎвЂљР Вµ
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† ChatsApi.PinMessageAsync Р Т‘Р В»РЎРЏ Р В·Р В°Р С”РЎР‚Р ВµР С—Р В»Р ВµР Р…Р С‘РЎРЏ РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘РЎРЏ

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types.Requests;

/// <summary>
/// Represents a request to pin a message in a chat.
/// </summary>
public class PinMessageRequest
{
    /// <summary>
    /// Gets or sets the message ID to pin.
    /// </summary>
    /// <value>
    /// The message ID to pin. Corresponds to the Message.body.mid field.
    /// </value>
    [Required(ErrorMessage = "Message ID is required.")]
    [JsonPropertyName("message_id")]
    public string MessageId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether to notify chat participants.
    /// </summary>
    /// <value>
    /// True to notify participants with a system message about pinning (default: true); otherwise, false.
    /// If null, uses default value (true).
    /// </value>
    [JsonPropertyName("notify")]
    public bool? Notify { get; set; }
}




