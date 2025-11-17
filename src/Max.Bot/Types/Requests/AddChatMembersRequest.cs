// СЂСџвЂњРѓ [AddChatMembersRequest] - Р вЂ”Р В°Р С—РЎР‚Р С•РЎРѓ Р Р…Р В° Р Т‘Р С•Р В±Р В°Р Р†Р В»Р ВµР Р…Р С‘Р Вµ РЎС“РЎвЂЎР В°РЎРѓРЎвЂљР Р…Р С‘Р С”Р С•Р Р† Р Р† РЎвЂЎР В°РЎвЂљ
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р В·Р В°Р С—РЎР‚Р С•РЎРѓ Р Т‘Р В»РЎРЏ Р Т‘Р С•Р В±Р В°Р Р†Р В»Р ВµР Р…Р С‘РЎРЏ РЎС“РЎвЂЎР В°РЎРѓРЎвЂљР Р…Р С‘Р С”Р С•Р Р† Р Р† РЎвЂЎР В°РЎвЂљ
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, System.ComponentModel.DataAnnotations
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† ChatsApi.AddChatMembersAsync Р Т‘Р В»РЎРЏ Р Т‘Р С•Р В±Р В°Р Р†Р В»Р ВµР Р…Р С‘РЎРЏ РЎС“РЎвЂЎР В°РЎРѓРЎвЂљР Р…Р С‘Р С”Р С•Р Р†

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types.Requests;

/// <summary>
/// Represents a request to add members to a chat.
/// </summary>
public class AddChatMembersRequest
{
    /// <summary>
    /// Gets or sets the array of user IDs to add to the chat.
    /// </summary>
    /// <value>
    /// The array of user IDs. Must not be null or empty.
    /// </value>
    [Required(ErrorMessage = "User IDs array is required.")]
    [MinLength(1, ErrorMessage = "At least one user ID must be provided.")]
    [JsonPropertyName("user_ids")]
    public long[] UserIds { get; set; } = Array.Empty<long>();
}




