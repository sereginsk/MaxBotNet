// СЂСџвЂњРѓ [UpdateFilterUtilities] - Р Р€РЎвЂљР С‘Р В»Р С‘РЎвЂљРЎвЂ№ РЎвЂћР С‘Р В»РЎРЉРЎвЂљРЎР‚Р В°РЎвЂ Р С‘Р С‘ Р С•Р В±Р Р…Р С•Р Р†Р В»Р ВµР Р…Р С‘Р в„–
// СЂСџР‹Р‡ Core function: Р РЋР С•Р С—Р С•РЎРѓРЎвЂљР В°Р Р†Р В»РЎРЏР ВµРЎвЂљ РЎвЂћР С‘Р В»РЎРЉРЎвЂљРЎР‚РЎвЂ№ РЎвЂљР С‘Р С—Р С•Р Р†/РЎР‹Р В·Р ВµРЎР‚Р Р…Р ВµР в„–Р СР С•Р Р† Р С‘ Р С—РЎР‚Р С•Р Р†Р ВµРЎР‚РЎРЏР ВµРЎвЂљ Р Т‘Р С•РЎРѓРЎвЂљР В°Р Р†Р С”РЎС“
// СЂСџвЂќвЂ” Key dependencies: System.Collections.Generic, Max.Bot.Configuration, Max.Bot.Types, Max.Bot.Types.Enums
// СЂСџвЂ™РЋ Usage: Р С›Р В±Р ВµРЎРѓР С—Р ВµРЎвЂЎР С‘Р Р†Р В°Р ВµРЎвЂљ Р С—Р С•Р Р†РЎвЂљР С•РЎР‚Р Р…Р С•Р Вµ Р С‘РЎРѓР С—Р С•Р В»РЎРЉР В·Р С•Р Р†Р В°Р Р…Р С‘Р Вµ РЎвЂћР С‘Р В»РЎРЉРЎвЂљРЎР‚Р В°РЎвЂ Р С‘Р С‘ Р СР ВµР В¶Р Т‘РЎС“ poller Р С‘ webhook

using System;
using System.Collections.Generic;
using System.Linq;
using Max.Bot.Configuration;
using Max.Bot.Types;
using Max.Bot.Types.Enums;

namespace Max.Bot.Polling;

internal static class UpdateFilterUtilities
{
    public static HashSet<UpdateType>? BuildTypeFilter(MaxBotOptions options)
    {
        var candidates = options.Handling.AllowedUpdateTypes;
        if (candidates is { Count: > 0 })
        {
            return new HashSet<UpdateType>(candidates);
        }

        candidates = options.Polling.AllowedUpdateTypes;
        if (candidates is { Count: > 0 })
        {
            return new HashSet<UpdateType>(candidates);
        }

        return null;
    }

    public static HashSet<string>? BuildAllowedUsernames(MaxBotOptions options)
    {
        if (options.Handling.AllowedUsernames is { Count: > 0 })
        {
            return new HashSet<string>(
                options.Handling.AllowedUsernames.Where(static name => !string.IsNullOrWhiteSpace(name)),
                StringComparer.OrdinalIgnoreCase);
        }

        return null;
    }

    public static bool ShouldDispatch(Update update, HashSet<UpdateType>? typeFilter, HashSet<string>? allowedUsernames)
    {
        if (typeFilter != null && !typeFilter.Contains(update.Type))
        {
            return false;
        }

        if (allowedUsernames != null && allowedUsernames.Count > 0)
        {
            var username = ExtractUsername(update);
            if (string.IsNullOrWhiteSpace(username) || !allowedUsernames.Contains(username))
            {
                return false;
            }
        }

        return true;
    }

    public static string? ExtractUsername(Update update)
    {
        return update.Message?.From?.Username ??
               update.Message?.Sender?.Username ??
               update.CallbackQuery?.From?.Username;
    }
}




