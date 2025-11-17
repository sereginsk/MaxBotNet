// СЂСџвЂњРѓ [SendChatActionRequest] - Р вЂ”Р В°Р С—РЎР‚Р С•РЎРѓ Р Р…Р В° Р С•РЎвЂљР С—РЎР‚Р В°Р Р†Р С”РЎС“ Р Т‘Р ВµР в„–РЎРѓРЎвЂљР Р†Р С‘РЎРЏ Р Р† РЎвЂЎР В°РЎвЂљ
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р ВµР Т‘РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р В·Р В°Р С—РЎР‚Р С•РЎРѓ Р Т‘Р В»РЎРЏ Р С•РЎвЂљР С—РЎР‚Р В°Р Р†Р С”Р С‘ Р Т‘Р ВµР в„–РЎРѓРЎвЂљР Р†Р С‘РЎРЏ Р В±Р С•РЎвЂљР В° Р Р† РЎвЂЎР В°РЎвЂљ
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization, Max.Bot.Types.Enums
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† ChatsApi.SendChatActionAsync Р Т‘Р В»РЎРЏ Р С•РЎвЂљР С—РЎР‚Р В°Р Р†Р С”Р С‘ Р Т‘Р ВµР в„–РЎРѓРЎвЂљР Р†Р С‘Р в„–

using System.Text.Json.Serialization;
using Max.Bot.Types.Enums;

namespace Max.Bot.Types.Requests;

/// <summary>
/// Represents a request to send a chat action.
/// </summary>
public class SendChatActionRequest
{
    /// <summary>
    /// Gets or sets the action to send.
    /// </summary>
    /// <value>The chat action to send.</value>
    [JsonPropertyName("action")]
    public ChatAction Action { get; set; }
}




