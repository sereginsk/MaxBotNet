// СЂСџвЂњРѓ [Audio] - Р СљР С•Р Т‘Р ВµР В»РЎРЉ Р В°РЎС“Р Т‘Р С‘Р С• Р Р† Max Messenger
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р С‘Р Р…РЎвЂћР С•РЎР‚Р СР В°РЎвЂ Р С‘РЎР‹ Р С•Р В± Р В°РЎС“Р Т‘Р С‘Р С•
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† Message Р Т‘Р В»РЎРЏ Р С—РЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»Р ВµР Р…Р С‘РЎРЏ Р В°РЎС“Р Т‘Р С‘Р С• Р Р†Р В»Р С•Р В¶Р ВµР Р…Р С‘Р в„–

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents an audio file in Max Messenger.
/// </summary>
public class Audio
{
    /// <summary>
    /// Gets or sets the unique identifier of the audio file.
    /// </summary>
    /// <value>The unique identifier of the audio file.</value>
    [Range(1, long.MaxValue, ErrorMessage = "Audio ID must be greater than zero.")]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the file identifier of the audio file.
    /// </summary>
    /// <value>The file identifier of the audio file.</value>
    [Required(ErrorMessage = "File ID is required.")]
    [StringLength(256, MinimumLength = 1, ErrorMessage = "File ID must be between 1 and 256 characters.")]
    [JsonPropertyName("fileId")]
    public string FileId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the duration of the audio file in seconds.
    /// </summary>
    /// <value>The duration of the audio file in seconds, or null if not available.</value>
    [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than zero if provided.")]
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    /// <summary>
    /// Gets or sets the size of the audio file in bytes.
    /// </summary>
    /// <value>The size of the audio file in bytes, or null if not available.</value>
    [Range(1, long.MaxValue, ErrorMessage = "File size must be greater than zero if provided.")]
    [JsonPropertyName("fileSize")]
    public long? FileSize { get; set; }

    /// <summary>
    /// Gets or sets the MIME type of the audio file.
    /// </summary>
    /// <value>The MIME type of the audio file (e.g., "audio/mpeg"), or null if not available.</value>
    [StringLength(64, ErrorMessage = "MIME type must not exceed 64 characters.")]
    [JsonPropertyName("mimeType")]
    public string? MimeType { get; set; }

    /// <summary>
    /// Gets or sets the URL of the audio file.
    /// </summary>
    /// <value>The URL of the audio file, or null if not available.</value>
    [Url(ErrorMessage = "URL must be a valid URL if provided.")]
    [StringLength(2048, ErrorMessage = "URL must not exceed 2048 characters.")]
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}

