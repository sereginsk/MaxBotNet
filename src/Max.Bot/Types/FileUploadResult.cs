using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents the result of uploading file data to an upload URL.
/// </summary>
public class FileUploadResult
{
    /// <summary>
    /// Gets or sets the uploaded media token.
    /// </summary>
    [JsonPropertyName("token")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Token { get; set; }

    /// <summary>
    /// Gets or sets additional properties received in the response.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, object>? AdditionalProperties { get; set; }
}
