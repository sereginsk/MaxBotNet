// СЂСџвЂњРѓ [MessageType] - Р СћР С‘Р С— РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘РЎРЏ Р Р† Max Messenger
// СЂСџР‹Р‡ Core function: Р СџР ВµРЎР‚Р ВµРЎвЂЎР С‘РЎРѓР В»Р ВµР Р…Р С‘Р Вµ РЎвЂљР С‘Р С—Р С•Р Р† РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘Р в„– (text, image, file)
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† Р СР С•Р Т‘Р ВµР В»Р С‘ Message Р Т‘Р В»РЎРЏ Р С•Р С—РЎР‚Р ВµР Т‘Р ВµР В»Р ВµР Р…Р С‘РЎРЏ РЎвЂљР С‘Р С—Р В° РЎРѓР С•Р С•Р В±РЎвЂ°Р ВµР Р…Р С‘РЎРЏ

using System.Text.Json.Serialization;

namespace Max.Bot.Types.Enums;

/// <summary>
/// Represents the type of a message.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MessageType
{
    /// <summary>
    /// Text message.
    /// </summary>
    Text,

    /// <summary>
    /// Image message.
    /// </summary>
    Image,

    /// <summary>
    /// File message.
    /// </summary>
    File
}

