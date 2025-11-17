// СЂСџвЂњРѓ [IMaxBotApi] - Р вЂњР В»Р В°Р Р†Р Р…РЎвЂ№Р в„– Р С‘Р Р…РЎвЂљР ВµРЎР‚РЎвЂћР ВµР в„–РЎРѓ API Max Messenger Bot
// СЂСџР‹Р‡ Core function: Р С›Р В±РЎР‰Р ВµР Т‘Р С‘Р Р…РЎРЏР ВµРЎвЂљ Р Р†РЎРѓР Вµ Р С–РЎР‚РЎС“Р С—Р С—РЎвЂ№ API Р СР ВµРЎвЂљР С•Р Т‘Р С•Р Р† Р Р† Р ВµР Т‘Р С‘Р Р…РЎвЂ№Р в„– Р С‘Р Р…РЎвЂљР ВµРЎР‚РЎвЂћР ВµР в„–РЎРѓ
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Api
// СЂСџвЂ™РЋ Usage: Р ВРЎРѓР С—Р С•Р В»РЎРЉР В·РЎС“Р ВµРЎвЂљРЎРѓРЎРЏ Р С”Р В°Р С” Р С–Р В»Р В°Р Р†Р Р…РЎвЂ№Р в„– Р С‘Р Р…РЎвЂљР ВµРЎР‚РЎвЂћР ВµР в„–РЎРѓ Р Т‘Р В»РЎРЏ РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ РЎРѓ Max Bot API

namespace Max.Bot.Api;

/// <summary>
/// Main interface for the Max Messenger Bot API.
/// </summary>
public interface IMaxBotApi
{
    /// <summary>
    /// Gets the bot-related API methods.
    /// </summary>
    /// <value>The bot API interface.</value>
    IBotApi Bot { get; }

    /// <summary>
    /// Gets the message-related API methods.
    /// </summary>
    /// <value>The messages API interface.</value>
    IMessagesApi Messages { get; }

    /// <summary>
    /// Gets the chat-related API methods.
    /// </summary>
    /// <value>The chats API interface.</value>
    IChatsApi Chats { get; }

    /// <summary>
    /// Gets the user-related API methods.
    /// </summary>
    /// <value>The users API interface.</value>
    IUsersApi Users { get; }

    /// <summary>
    /// Gets the file-related API methods.
    /// </summary>
    /// <value>The files API interface.</value>
    IFilesApi Files { get; }

    /// <summary>
    /// Gets the subscriptions/updates-related API methods.
    /// </summary>
    /// <value>The subscriptions API interface.</value>
    ISubscriptionsApi Subscriptions { get; }
}

