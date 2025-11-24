using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Max.Bot.Types.Enums;

namespace Max.Bot.Types;

/// <summary>
/// Represents an update from Max Messenger.
/// </summary>
public class Update
{
    /// <summary>
    /// Gets or sets the unique identifier of the update.
    /// </summary>
    /// <value>The unique identifier of the update.</value>
    [Range(0, long.MaxValue, ErrorMessage = "Update ID cannot be negative.")]
    [JsonPropertyName("update_id")]
    public long UpdateId { get; set; }

    /// <summary>
    /// Gets or sets the type of the update.
    /// </summary>
    /// <value>The type of the update (message or callback_query).</value>
    /// <remarks>
    /// API returns "update_type" field (e.g., "message_created"), but we map it to UpdateType enum.
    /// If update_type is not present, we infer type from presence of "message" or "callback_query" fields.
    /// </remarks>
    [JsonPropertyName("update_type")]
    public string? UpdateTypeRaw { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of the update (Unix timestamp in milliseconds).
    /// </summary>
    /// <value>The timestamp when the update was created.</value>
    [Range(0, long.MaxValue, ErrorMessage = "Timestamp cannot be negative.")]
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    /// <summary>
    /// Gets or sets the user locale for this update.
    /// </summary>
    /// <value>The locale code (e.g., "ru", "en").</value>
    [JsonPropertyName("user_locale")]
    public string? UserLocale { get; set; }


    /// <summary>
    /// Gets the typed message update wrapper.
    /// </summary>
    /// <value>The message update wrapper, or null if this update is not a message update.</value>
    [JsonIgnore]
    public MessageUpdate? MessageUpdate
    {
        get
        {
            if (Message == null)
            {
                return null;
            }

            return new MessageUpdate
            {
                UpdateId = UpdateId,
                Timestamp = Timestamp,
                UserLocale = UserLocale,
                Message = Message
            };
        }
    }

    /// <summary>
    /// Gets the typed callback query update wrapper.
    /// </summary>
    /// <value>The callback query update wrapper, or null if this update is not a callback query update.</value>
    [JsonIgnore]
    public CallbackQueryUpdate? CallbackQueryUpdate
    {
        get
        {
            if (CallbackQuery == null)
            {
                return null;
            }

            return new CallbackQueryUpdate
            {
                UpdateId = UpdateId,
                Timestamp = Timestamp,
                UserLocale = UserLocale,
                CallbackQuery = CallbackQuery
            };
        }
    }

    /// <summary>
    /// Gets the type of the update as enum.
    /// </summary>
    /// <value>The type of the update (message or callback_query).</value>
    [JsonIgnore]
    public UpdateType Type
    {
        get
        {
            // * Infer type from update_type field or from presence of message/callbackQuery
            if (!string.IsNullOrEmpty(UpdateTypeRaw))
            {
                // Check for callback first, as "message_callback" contains both "message" and "callback"
                if (UpdateTypeRaw.Contains("callback", StringComparison.OrdinalIgnoreCase))
                {
                    return UpdateType.CallbackQuery;
                }
                if (UpdateTypeRaw.Contains("message", StringComparison.OrdinalIgnoreCase))
                {
                    return UpdateType.Message;
                }
            }

            // * Fallback: infer from presence of message or callback_query fields
            if (Message != null)
            {
                return UpdateType.Message;
            }
            if (CallbackQuery != null)
            {
                return UpdateType.CallbackQuery;
            }

            return UpdateType.Message; // Default to Message
        }
    }

    /// <summary>
    /// Gets or sets the message in this update (if type is Message).
    /// This property is used for JSON deserialization and maintains backward compatibility.
    /// </summary>
    /// <value>The message in this update, or null if not available.</value>
    [JsonPropertyName("message")]
    public Message? Message { get; set; }

    /// <summary>
    /// Gets or sets the callback query in this update (if type is CallbackQuery).
    /// This property is used for JSON deserialization and maintains backward compatibility.
    /// </summary>
    /// <value>The callback query in this update, or null if not available.</value>
    [JsonPropertyName("callback_query")]
    public CallbackQuery? CallbackQuery { get; set; }
}

