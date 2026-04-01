using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents a Max Messenger user.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// </summary>
    /// <value>The unique identifier of the user.</value>
    [Range(1, long.MaxValue, ErrorMessage = "User ID must be greater than zero.")]
    [JsonPropertyName("user_id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    /// <value>The username of the user, or null if not available.</value>
    [StringLength(64, MinimumLength = 1, ErrorMessage = "Username must be between 1 and 64 characters.")]
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    /// <value>The first name of the user, or null if not available.</value>
    [StringLength(64, ErrorMessage = "First name must not exceed 64 characters.")]
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    /// <value>The last name of the user, or null if not available.</value>
    [StringLength(64, ErrorMessage = "Last name must not exceed 64 characters.")]
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is a bot.
    /// </summary>
    /// <value>True if the user is a bot; otherwise, false.</value>
    [JsonPropertyName("is_bot")]
    public bool IsBot { get; set; }

    /// <summary>
    /// Gets or sets the last activity time of the user (Unix timestamp in milliseconds).
    /// </summary>
    /// <value>The timestamp of the user's last activity.</value>
    [Range(0, long.MaxValue, ErrorMessage = "Last activity time cannot be negative.")]
    [JsonPropertyName("last_activity_time")]
    public long? LastActivityTime { get; set; }

    /// <summary>
    /// Join channel time (Unix timestamp in milliseconds).
    /// </summary>
    /// <value>The timestamp of the user's join time or null if not available.</value>
    [Range(0, long.MaxValue, ErrorMessage = "Join time cannot be negative.")]
    [JsonPropertyName("join_time")]
    public long? JoinTime { get; set; }

    /// <summary>
    /// Gets or sets the avatar url of the user.
    /// </summary>
    /// <value>Avatar url  of the user, or null if not available.</value>
    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// Gets or sets the full avatar url of the user.
    /// </summary>
    /// <value>Full avatar url of the user, or null if not available.</value>
    [JsonPropertyName("full_avatar_url")]
    public string? FullAvatarUrl { get; set; }

}

