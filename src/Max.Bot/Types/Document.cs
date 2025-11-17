// СЂСџвЂњРѓ [Document] - Р СљР С•Р Т‘Р ВµР В»РЎРЉ Р Т‘Р С•Р С”РЎС“Р СР ВµР Р…РЎвЂљР В° Р Р† Max Messenger
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р С‘Р Р…РЎвЂћР С•РЎР‚Р СР В°РЎвЂ Р С‘РЎР‹ Р С• Р Т‘Р С•Р С”РЎС“Р СР ВµР Р…РЎвЂљР Вµ
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† Message Р Т‘Р В»РЎРЏ Р С—РЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»Р ВµР Р…Р С‘РЎРЏ Р Т‘Р С•Р С”РЎС“Р СР ВµР Р…РЎвЂљР В° Р Р†Р В»Р С•Р В¶Р ВµР Р…Р С‘Р в„–

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents a document file in Max Messenger.
/// </summary>
public class Document
{
    /// <summary>
    /// Gets or sets the unique identifier of the document.
    /// </summary>
    /// <value>The unique identifier of the document.</value>
    [Range(1, long.MaxValue, ErrorMessage = "Document ID must be greater than zero.")]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the file identifier of the document.
    /// </summary>
    /// <value>The file identifier of the document.</value>
    [Required(ErrorMessage = "File ID is required.")]
    [StringLength(256, MinimumLength = 1, ErrorMessage = "File ID must be between 1 and 256 characters.")]
    [JsonPropertyName("fileId")]
    public string FileId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the document file.
    /// </summary>
    /// <value>The name of the document file, or null if not available.</value>
    [StringLength(256, ErrorMessage = "File name must not exceed 256 characters.")]
    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    /// <summary>
    /// Gets or sets the size of the document file in bytes.
    /// </summary>
    /// <value>The size of the document file in bytes, or null if not available.</value>
    [Range(1, long.MaxValue, ErrorMessage = "File size must be greater than zero if provided.")]
    [JsonPropertyName("fileSize")]
    public long? FileSize { get; set; }

    /// <summary>
    /// Gets or sets the MIME type of the document.
    /// </summary>
    /// <value>The MIME type of the document (e.g., "application/pdf"), or null if not available.</value>
    [StringLength(64, ErrorMessage = "MIME type must not exceed 64 characters.")]
    [JsonPropertyName("mimeType")]
    public string? MimeType { get; set; }

    /// <summary>
    /// Gets or sets the URL of the document.
    /// </summary>
    /// <value>The URL of the document, or null if not available.</value>
    [Url(ErrorMessage = "URL must be a valid URL if provided.")]
    [StringLength(2048, ErrorMessage = "URL must not exceed 2048 characters.")]
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}

