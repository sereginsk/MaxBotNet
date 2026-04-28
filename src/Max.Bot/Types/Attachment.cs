using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
    /// <value>The type of the attachment (image, file, inline_keyboard, location, contact).</value>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
}

/// <summary>
/// Represents a photo attachment.
/// Data fields are flat at the attachment level to match the actual API response format.
/// </summary>
public class PhotoAttachment : Attachment
{
    /// <summary>
    /// Gets or sets the unique identifier of the photo.
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the file identifier of the photo.
    /// </summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the width of the photo in pixels.
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the photo in pixels.
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }

    /// <summary>
    /// Gets or sets the size of the photo file in bytes.
    /// </summary>
    [JsonPropertyName("file_size")]
    public long? FileSize { get; set; }

    /// <summary>
    /// Gets or sets the URL of the photo.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PhotoAttachment"/> class.
    /// </summary>
    public PhotoAttachment() => Type = AttachmentTypeNames.Image;
}

/// <summary>
/// Represents a video attachment.
/// Data fields are flat at the attachment level to match the actual API response format.
/// </summary>
public class VideoAttachment : Attachment
{
    /// <summary>
    /// Gets or sets the unique identifier of the video.
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the file identifier of the video.
    /// </summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the width of the video in pixels.
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the video in pixels.
    /// </summary>
    [JsonPropertyName("height")]
    public int? Height { get; set; }

    /// <summary>
    /// Gets or sets the duration of the video in seconds.
    /// </summary>
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    /// <summary>
    /// Gets or sets the size of the video file in bytes.
    /// </summary>
    [JsonPropertyName("file_size")]
    public long? FileSize { get; set; }

    /// <summary>
    /// Gets or sets the MIME type of the video.
    /// </summary>
    [JsonPropertyName("mime_type")]
    public string? MimeType { get; set; }

    /// <summary>
    /// Gets or sets the URL of the video.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="VideoAttachment"/> class.
    /// </summary>
    public VideoAttachment() => Type = AttachmentTypeNames.Video;
}

/// <summary>
/// Represents an audio attachment.
/// Data fields are flat at the attachment level to match the actual API response format.
/// </summary>
public class AudioAttachment : Attachment
{
    /// <summary>
    /// Gets or sets the unique identifier of the audio file.
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the file identifier of the audio file.
    /// </summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the duration of the audio file in seconds.
    /// </summary>
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    /// <summary>
    /// Gets or sets the size of the audio file in bytes.
    /// </summary>
    [JsonPropertyName("file_size")]
    public long? FileSize { get; set; }

    /// <summary>
    /// Gets or sets the MIME type of the audio file.
    /// </summary>
    [JsonPropertyName("mime_type")]
    public string? MimeType { get; set; }

    /// <summary>
    /// Gets or sets the URL of the audio file.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AudioAttachment"/> class.
    /// </summary>
    public AudioAttachment() => Type = AttachmentTypeNames.Audio;
}

/// <summary>
/// Represents a document attachment.
/// Data fields are flat at the attachment level to match the actual API response format.
/// </summary>
public class DocumentAttachment : Attachment
{
    /// <summary>
    /// Gets or sets the unique identifier of the document.
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the file identifier of the document.
    /// </summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the document file.
    /// </summary>
    [JsonPropertyName("file_name")]
    public string? FileName { get; set; }

    /// <summary>
    /// Gets or sets the size of the document file in bytes.
    /// </summary>
    [JsonPropertyName("file_size")]
    public long? FileSize { get; set; }

    /// <summary>
    /// Gets or sets the MIME type of the document.
    /// </summary>
    [JsonPropertyName("mime_type")]
    public string? MimeType { get; set; }

    /// <summary>
    /// Gets or sets the URL of the document.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DocumentAttachment"/> class.
    /// </summary>
    public DocumentAttachment() => Type = AttachmentTypeNames.File;
}

/// <summary>
/// Represents a location attachment.
/// </summary>
public class LocationAttachment : Attachment
{
    /// <summary>
    /// Gets or sets the location's latitude.
    /// </summary>
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    /// <summary>
    /// Gets or sets the location's longitude.
    /// </summary>
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LocationAttachment"/> class.
    /// </summary>
    public LocationAttachment() => Type = AttachmentTypeNames.Location;
}

/// <summary>
/// Represents a contact attachment.
/// </summary>
public class ContactAttachment : Attachment
{
    /// <summary>
    /// Gets or sets contact information in VCF format.
    /// </summary>
    [JsonPropertyName("vcf_info")]
    public string? VcfInfo { get; set; }

    /// <summary>
    /// Gets or sets contact information.
    /// </summary>
    [JsonPropertyName("max_info")]
    public ContactInfo? MaxInfo { get; set; }

    /// <summary>
    /// Gets or sets the contact attachment hash.
    /// </summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; set; }

    /// <summary>
    /// Gets the phone number from the contact.
    /// Tries MaxInfo.PhoneNumber first, then parses from VcfInfo.
    /// Returns null if no phone number is available.
    /// </summary>
    [JsonIgnore]
    public string? PhoneNumber => ContactHelpers.GetPhoneNumber(this);

    /// <summary>
    /// Gets the full name from the contact.
    /// Tries MaxInfo.FullName first, then parses from VcfInfo.
    /// Returns null if no full name is available.
    /// </summary>
    [JsonIgnore]
    public string? FullName => ContactHelpers.GetFullName(this);

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactAttachment"/> class.
    /// </summary>
    public ContactAttachment() => Type = AttachmentTypeNames.Contact;
}

/// <summary>
/// Represents an inline keyboard attachment.
/// </summary>
public class InlineKeyboardAttachment : Attachment
{
    /// <summary>
    /// Gets or sets the callback ID for this keyboard attachment.
    /// </summary>
    [JsonPropertyName("callback_id")]
    public string? CallbackId { get; set; }

    /// <summary>
    /// Gets or sets the payload containing the keyboard buttons.
    /// </summary>
    [JsonPropertyName("payload")]
    public Dictionary<string, object>? Payload { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="InlineKeyboardAttachment"/> class.
    /// </summary>
    public InlineKeyboardAttachment() => Type = AttachmentTypeNames.InlineKeyboard;
}

internal static class AttachmentTypeNames
{
    public const string Image = "image";
    public const string Video = "video";
    public const string Audio = "audio";
    public const string File = "file";
    public const string InlineKeyboard = "inline_keyboard";
    public const string Location = "location";
    public const string Contact = "contact";
}
