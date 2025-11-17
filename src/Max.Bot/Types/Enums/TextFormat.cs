// СЂСџвЂњРѓ [TextFormat] - Р В¤Р С•РЎР‚Р СР В°РЎвЂљ РЎвЂљР ВµР С”РЎРѓРЎвЂљР В° Р Р† Max Messenger
// СЂСџР‹Р‡ Core function: Р СџР ВµРЎР‚Р ВµРЎвЂЎР С‘РЎРѓР В»Р ВµР Р…Р С‘Р Вµ РЎвЂћР С•РЎР‚Р СР В°РЎвЂљР С•Р Р† РЎвЂљР ВµР С”РЎРѓРЎвЂљР В° (markdown, html)
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† Р СР С•Р Т‘Р ВµР В»РЎРЏРЎвЂ¦ Р В·Р В°Р С—РЎР‚Р С•РЎРѓР С•Р Р† Р Т‘Р В»РЎРЏ РЎвЂћР С•РЎР‚Р СР В°РЎвЂљР С‘РЎР‚Р С•Р Р†Р В°Р Р…Р С‘РЎРЏ РЎвЂљР ВµР С”РЎРѓРЎвЂљР В°

using System.Text.Json.Serialization;

namespace Max.Bot.Types.Enums;

/// <summary>
/// Represents the text format for message content.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TextFormat
{
    /// <summary>
    /// Markdown formatting.
    /// </summary>
    Markdown,

    /// <summary>
    /// HTML formatting.
    /// </summary>
    Html
}




