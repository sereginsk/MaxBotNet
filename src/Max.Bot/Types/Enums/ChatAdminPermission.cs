namespace Max.Bot.Types.Enums;

/// <summary>
/// Represents chat admin permissions returned by the MAX API.
/// Serialized as snake_case by <see cref="Max.Bot.Networking.MaxJsonSerializer"/>
/// (global <c>JsonStringEnumConverter</c> with <c>SnakeCaseLower</c> policy).
/// </summary>
public enum ChatAdminPermission
{
    /// <summary>
    /// Permission to read all messages in the chat.
    /// Serializes as "read_all_messages".
    /// </summary>
    ReadAllMessages,

    /// <summary>
    /// Permission to add or remove members.
    /// Serializes as "add_remove_members".
    /// </summary>
    AddRemoveMembers,

    /// <summary>
    /// Permission to add admins.
    /// Serializes as "add_admins".
    /// </summary>
    AddAdmins,

    /// <summary>
    /// Permission to change chat info (title, icon, etc.).
    /// Serializes as "change_chat_info".
    /// </summary>
    ChangeChatInfo,

    /// <summary>
    /// Permission to pin messages.
    /// Serializes as "pin_message".
    /// </summary>
    PinMessage,

    /// <summary>
    /// Permission to write messages (for restricted chats).
    /// Serializes as "write".
    /// </summary>
    Write,
}
