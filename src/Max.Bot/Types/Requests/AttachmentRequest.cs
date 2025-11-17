// СЂСџвЂњРѓ [AttachmentRequest] - Р вЂ”Р В°Р С—РЎР‚Р С•РЎРѓ Р Р…Р В° РЎРѓР С•Р В·Р Т‘Р В°Р Р…Р С‘Р Вµ Р Р†Р В»Р С•Р В¶Р ВµР Р…Р С‘РЎРЏ
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р В·Р В°Р С—РЎР‚Р С•РЎРѓ Р Т‘Р В»РЎРЏ РЎРѓР С•Р В·Р Т‘Р В°Р Р…Р С‘РЎРЏ Р Р†Р В»Р С•Р В¶Р ВµР Р…Р С‘РЎРЏ Р С—РЎР‚Р С‘ Р С•РЎвЂљР С—РЎР‚Р В°Р Р†Р С”Р Вµ РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘РЎРЏ
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† SendMessageRequest Р Т‘Р В»РЎРЏ РЎРѓР С•Р В·Р Т‘Р В°Р Р…Р С‘РЎРЏ Р Р†Р В»Р С•Р В¶Р ВµР Р…Р С‘Р в„– РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘РЎРЏ

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types.Requests;

/// <summary>
/// Represents a request to create an attachment for a message.
/// </summary>
public class AttachmentRequest
{
    /// <summary>
    /// Gets or sets the type of the attachment.
    /// </summary>
    /// <value>The type of the attachment (image, video, audio, or file).</value>
    [Required(ErrorMessage = "Attachment type is required.")]
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    /// <summary>
    /// Gets or sets the payload of the attachment.
    /// </summary>
    /// <value>
    /// The payload object containing attachment data (e.g., token for video/audio,
    /// or JSON object returned after file upload for image/file).
    /// </value>
    [Required(ErrorMessage = "Attachment payload is required.")]
    [JsonPropertyName("payload")]
    public object Payload { get; set; } = null!;
}

