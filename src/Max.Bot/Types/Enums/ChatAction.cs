// СЂСџвЂњРѓ [ChatAction] - Enum Р Т‘Р В»РЎРЏ Р Т‘Р ВµР в„–РЎРѓРЎвЂљР Р†Р С‘Р в„– Р В±Р С•РЎвЂљР В° Р Р† РЎвЂЎР В°РЎвЂљР Вµ
// СЂСџР‹Р‡ Core function: Р С›Р С—РЎР‚Р ВµР Т‘Р ВµР В»РЎРЏР ВµРЎвЂљ Р Р†Р С•Р В·Р СР С•Р В¶Р Р…РЎвЂ№Р Вµ Р Т‘Р ВµР в„–РЎРѓРЎвЂљР Р†Р С‘РЎРЏ Р В±Р С•РЎвЂљР В° Р Р† РЎвЂЎР В°РЎвЂљР Вµ
// СЂСџвЂќвЂ” Key dependencies: System.Text.Json.Serialization
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† SendChatActionRequest Р Т‘Р В»РЎРЏ Р С•РЎвЂљР С—РЎР‚Р В°Р Р†Р С”Р С‘ Р Т‘Р ВµР в„–РЎРѓРЎвЂљР Р†Р С‘Р в„–

using System.Text.Json.Serialization;

namespace Max.Bot.Types.Enums;

/// <summary>
/// Represents actions that can be sent by the bot in a chat.
/// </summary>
public enum ChatAction
{
    /// <summary>
    /// Bot is typing a message.
    /// </summary>
    [JsonPropertyName("typing_on")]
    TypingOn,

    /// <summary>
    /// Bot is sending a photo.
    /// </summary>
    [JsonPropertyName("sending_photo")]
    SendingPhoto,

    /// <summary>
    /// Bot is sending a video.
    /// </summary>
    [JsonPropertyName("sending_video")]
    SendingVideo,

    /// <summary>
    /// Bot is sending an audio file.
    /// </summary>
    [JsonPropertyName("sending_audio")]
    SendingAudio,

    /// <summary>
    /// Bot is sending a file.
    /// </summary>
    [JsonPropertyName("sending_file")]
    SendingFile,

    /// <summary>
    /// Bot marks messages as seen.
    /// </summary>
    [JsonPropertyName("mark_seen")]
    MarkSeen
}

