// СЂСџвЂњРѓ [UpdateChatRequest] - Р вЂ”Р В°Р С—РЎР‚Р С•РЎРѓ Р Р…Р В° Р С‘Р В·Р СР ВµР Р…Р ВµР Р…Р С‘Р Вµ Р С‘Р Р…РЎвЂћР С•РЎР‚Р СР В°РЎвЂ Р С‘Р С‘ Р С• РЎвЂЎР В°РЎвЂљР Вµ
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р В·Р В°Р С—РЎР‚Р С•РЎРѓ Р Т‘Р В»РЎРЏ Р С‘Р В·Р СР ВµР Р…Р ВµР Р…Р С‘РЎРЏ Р С‘Р Р…РЎвЂћР С•РЎР‚Р СР В°РЎвЂ Р С‘Р С‘ Р С• РЎвЂЎР В°РЎвЂљР Вµ
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations, Max.Bot.Types
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† ChatsApi.UpdateChatAsync Р Т‘Р В»РЎРЏ Р С‘Р В·Р СР ВµР Р…Р ВµР Р…Р С‘РЎРЏ РЎвЂЎР В°РЎвЂљР В°

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Max.Bot.Types;

namespace Max.Bot.Types.Requests;

/// <summary>
/// Represents a request to update chat information.
/// </summary>
public class UpdateChatRequest
{
    /// <summary>
    /// Gets or sets the chat icon (photo attachment request).
    /// </summary>
    /// <value>
    /// The photo attachment request for the chat icon. All fields are mutually exclusive.
    /// If null, the icon is not changed.
    /// </value>
    [JsonPropertyName("icon")]
    public object? Icon { get; set; }

    /// <summary>
    /// Gets or sets the chat title.
    /// </summary>
    /// <value>
    /// The chat title (1-200 characters). If null, the title is not changed.
    /// </value>
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200 characters.")]
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the message ID to pin in the chat.
    /// </summary>
    /// <value>
    /// The message ID to pin. To remove the pinned message, use the unpin method.
    /// If null, the pin is not changed.
    /// </value>
    [JsonPropertyName("pin")]
    public string? Pin { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to notify chat participants.
    /// </summary>
    /// <value>
    /// True to notify participants (default: true); otherwise, false.
    /// If null, uses default value (true).
    /// </value>
    [JsonPropertyName("notify")]
    public bool? Notify { get; set; }
}




