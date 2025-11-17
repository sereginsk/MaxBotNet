// СЂСџвЂњРѓ [ChatType] - Р СћР С‘Р С— РЎвЂЎР В°РЎвЂљР В° Р Р† Max Messenger
// СЂСџР‹Р‡ Core function: Р СџР ВµРЎР‚Р ВµРЎвЂЎР С‘РЎРѓР В»Р ВµР Р…Р С‘Р Вµ РЎвЂљР С‘Р С—Р С•Р Р† РЎвЂЎР В°РЎвЂљР С•Р Р† (private, group, channel)
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† Р СР С•Р Т‘Р ВµР В»Р С‘ Chat Р Т‘Р В»РЎРЏ Р С•Р С—РЎР‚Р ВµР Т‘Р ВµР В»Р ВµР Р…Р С‘РЎРЏ РЎвЂљР С‘Р С—Р В° РЎвЂЎР В°РЎвЂљР В°

using System.Text.Json.Serialization;

namespace Max.Bot.Types.Enums;

/// <summary>
/// Represents the type of a chat.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ChatType
{
    /// <summary>
    /// Private chat with a user.
    /// </summary>
    Private,

    /// <summary>
    /// Group chat.
    /// </summary>
    Group,

    /// <summary>
    /// Channel.
    /// </summary>
    Channel
}

