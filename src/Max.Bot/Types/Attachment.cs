// СЂСџвЂњРѓ [Attachment] - Р СљР С•Р Т‘Р ВµР В»РЎРЉ Р Р†Р В»Р С•Р В¶Р ВµР Р…Р С‘РЎРЏ Р Р† Max Messenger
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р Р†Р В»Р С•Р В¶Р ВµР Р…Р С‘Р Вµ РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘РЎРЏ (Р С—Р С•Р В»Р С‘Р СР С•РЎР‚РЎвЂћР Р…Р В°РЎРЏ Р СР С•Р Т‘Р ВµР В»РЎРЉ)
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations, Max.Bot.Types.Enums
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† Message Р Т‘Р В»РЎРЏ Р С—РЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»Р ВµР Р…Р С‘РЎРЏ Р Р†Р В»Р С•Р В¶Р ВµР Р…Р С‘Р в„– РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘РЎРЏ

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Max.Bot.Types.Enums;

namespace Max.Bot.Types;

/// <summary>
/// Represents an attachment in a Max Messenger message.
/// This is a polymorphic type that can contain different media types (Photo, Video, Audio, Document).
/// </summary>
[JsonConverter(typeof(Converters.AttachmentJsonConverter))]
public abstract class Attachment
{
    /// <summary>
    /// Gets or sets the type of the attachment.
    /// </summary>
    /// <value>The type of the attachment (text, image, or file).</value>
    [JsonPropertyName("type")]
    public MessageType Type { get; set; }
}

/// <summary>
/// Represents a photo attachment.
/// </summary>
public class PhotoAttachment : Attachment
{
    /// <summary>
    /// Gets or sets the photo in this attachment.
    /// </summary>
    /// <value>The photo object.</value>
    [JsonPropertyName("photo")]
    public Photo Photo { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="PhotoAttachment"/> class.
    /// </summary>
    public PhotoAttachment()
    {
        Type = MessageType.Image;
    }
}

/// <summary>
/// Represents a video attachment.
/// </summary>
public class VideoAttachment : Attachment
{
    /// <summary>
    /// Gets or sets the video in this attachment.
    /// </summary>
    /// <value>The video object.</value>
    [JsonPropertyName("video")]
    public Video Video { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="VideoAttachment"/> class.
    /// </summary>
    public VideoAttachment()
    {
        Type = MessageType.File;
    }
}

/// <summary>
/// Represents an audio attachment.
/// </summary>
public class AudioAttachment : Attachment
{
    /// <summary>
    /// Gets or sets the audio in this attachment.
    /// </summary>
    /// <value>The audio object.</value>
    [JsonPropertyName("audio")]
    public Audio Audio { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="AudioAttachment"/> class.
    /// </summary>
    public AudioAttachment()
    {
        Type = MessageType.File;
    }
}

/// <summary>
/// Represents a document attachment.
/// </summary>
public class DocumentAttachment : Attachment
{
    /// <summary>
    /// Gets or sets the document in this attachment.
    /// </summary>
    /// <value>The document object.</value>
    [JsonPropertyName("document")]
    public Document Document { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="DocumentAttachment"/> class.
    /// </summary>
    public DocumentAttachment()
    {
        Type = MessageType.File;
    }
}

