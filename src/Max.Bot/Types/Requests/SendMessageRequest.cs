// СЂСџвЂњРѓ [SendMessageRequest] - Р вЂ”Р В°Р С—РЎР‚Р С•РЎРѓ Р Р…Р В° Р С•РЎвЂљР С—РЎР‚Р В°Р Р†Р С”РЎС“ РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘РЎРЏ
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р В·Р В°Р С—РЎР‚Р С•РЎРѓ Р Т‘Р В»РЎРЏ Р С•РЎвЂљР С—РЎР‚Р В°Р Р†Р С”Р С‘ РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘РЎРЏ РЎРѓ Р С—Р С•Р В»Р Р…Р С•Р в„– Р С—Р С•Р Т‘Р Т‘Р ВµРЎР‚Р В¶Р С”Р С•Р в„– Р Р†РЎРѓР ВµРЎвЂ¦ Р С—Р В°РЎР‚Р В°Р СР ВµРЎвЂљРЎР‚Р С•Р Р†
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations, Max.Bot.Types.Enums
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† MessagesApi.SendMessageAsync Р Т‘Р В»РЎРЏ Р С•РЎвЂљР С—РЎР‚Р В°Р Р†Р С”Р С‘ РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘Р в„– РЎРѓ Р Р†Р В»Р С•Р В¶Р ВµР Р…Р С‘РЎРЏР СР С‘ Р С‘ Р Т‘Р С•Р С—Р С•Р В»Р Р…Р С‘РЎвЂљР ВµР В»РЎРЉР Р…РЎвЂ№Р СР С‘ Р С—Р В°РЎР‚Р В°Р СР ВµРЎвЂљРЎР‚Р В°Р СР С‘

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Max.Bot.Types.Enums;

namespace Max.Bot.Types.Requests;

/// <summary>
/// Represents a request to send a message with full support for all parameters.
/// </summary>
public class SendMessageRequest
{
    /// <summary>
    /// Gets or sets the text content of the message.
    /// </summary>
    /// <value>The text content, or null if not applicable.</value>
    [StringLength(4000, ErrorMessage = "Text must not exceed 4000 characters.")]
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    /// <summary>
    /// Gets or sets the attachments for the message.
    /// </summary>
    /// <value>
    /// The attachments array. Each attachment must have a type (image, video, audio, file)
    /// and a payload object containing attachment data.
    /// </value>
    [JsonPropertyName("attachments")]
    public AttachmentRequest[]? Attachments { get; set; }

    /// <summary>
    /// Gets or sets the link to a message for forwarding or replying.
    /// </summary>
    /// <value>The linked message information, or null if not applicable.</value>
    [JsonPropertyName("link")]
    public NewMessageLink? Link { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to notify chat participants.
    /// </summary>
    /// <value>True to notify participants (default); otherwise, false.</value>
    [JsonPropertyName("notify")]
    public bool? Notify { get; set; }

    /// <summary>
    /// Gets or sets the text format for the message content.
    /// </summary>
    /// <value>The text format (markdown or html), or null for plain text.</value>
    [JsonPropertyName("format")]
    public TextFormat? Format { get; set; }
}

