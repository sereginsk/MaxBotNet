// СЂСџвЂњРѓ [ChatStatus] - Р РЋРЎвЂљР В°РЎвЂљРЎС“РЎРѓ РЎвЂЎР В°РЎвЂљР В° Р Р† Max Messenger
// СЂСџР‹Р‡ Core function: Р СџР ВµРЎР‚Р ВµРЎвЂЎР С‘РЎРѓР В»Р ВµР Р…Р С‘Р Вµ РЎРѓРЎвЂљР В°РЎвЂљРЎС“РЎРѓР С•Р Р† РЎвЂЎР В°РЎвЂљР В° (active, removed, left, closed)
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† Р СР С•Р Т‘Р ВµР В»Р С‘ Chat Р Т‘Р В»РЎРЏ Р С•Р С—РЎР‚Р ВµР Т‘Р ВµР В»Р ВµР Р…Р С‘РЎРЏ РЎРѓРЎвЂљР В°РЎвЂљРЎС“РЎРѓР В° РЎвЂЎР В°РЎвЂљР В°

using System.Text.Json.Serialization;

namespace Max.Bot.Types.Enums;

/// <summary>
/// Represents the status of a chat.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ChatStatus
{
    /// <summary>
    /// Bot is an active participant in the chat.
    /// </summary>
    Active,

    /// <summary>
    /// Bot was removed from the chat.
    /// </summary>
    Removed,

    /// <summary>
    /// Bot left the chat.
    /// </summary>
    Left,

    /// <summary>
    /// Chat was closed.
    /// </summary>
    Closed
}

