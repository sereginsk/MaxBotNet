// СЂСџвЂњРѓ [File] - Р СљР С•Р Т‘Р ВµР В»РЎРЉ РЎвЂћР В°Р в„–Р В»Р В° Р Р† Max Messenger
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р С‘Р Р…РЎвЂћР С•РЎР‚Р СР В°РЎвЂ Р С‘РЎР‹ Р С• РЎвЂћР В°Р в„–Р В»Р Вµ
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Т‘Р В»РЎРЏ РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ РЎРѓ РЎвЂћР В°Р в„–Р В»Р В°Р СР С‘ Р Р† Max Messenger API

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents a file in Max Messenger.
/// </summary>
public class File
{
    /// <summary>
    /// Gets or sets the unique identifier of the file.
    /// </summary>
    /// <value>The unique identifier of the file.</value>
    [Required(ErrorMessage = "File ID is required.")]
    [StringLength(256, MinimumLength = 1, ErrorMessage = "File ID must be between 1 and 256 characters.")]
    [JsonPropertyName("fileId")]
    public string FileId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the size of the file in bytes.
    /// </summary>
    /// <value>The size of the file in bytes, or null if not available.</value>
    [Range(1, long.MaxValue, ErrorMessage = "File size must be greater than zero if provided.")]
    [JsonPropertyName("fileSize")]
    public long? FileSize { get; set; }

    /// <summary>
    /// Gets or sets the file path or URL.
    /// </summary>
    /// <value>The file path or URL, or null if not available.</value>
    [StringLength(2048, ErrorMessage = "File path must not exceed 2048 characters.")]
    [JsonPropertyName("filePath")]
    public string? FilePath { get; set; }
}

