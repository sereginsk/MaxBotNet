// СЂСџвЂњРѓ [UpdateHandlingOptions] - Р СњР В°РЎРѓРЎвЂљРЎР‚Р С•Р в„–Р С”Р С‘ Р Т‘Р С‘РЎРѓР С—Р ВµРЎвЂљРЎвЂЎР ВµРЎР‚Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘ Р С•Р В±Р Р…Р С•Р Р†Р В»Р ВµР Р…Р С‘Р в„–
// СЂСџР‹Р‡ Core function: Р Р€Р С—РЎР‚Р В°Р Р†Р В»РЎРЏР ВµРЎвЂљ Р С•Р В±РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂЎР С‘Р С”Р В°Р СР С‘ (Р С—Р В°РЎР‚Р В°Р В»Р В»Р ВµР В»Р С‘Р В·Р С, РЎвЂљР В°Р в„–Р СР В°РЎС“РЎвЂљРЎвЂ№, РЎвЂћР С‘Р В»РЎРЉРЎвЂљРЎР‚РЎвЂ№)
// СЂСџвЂќвЂ” Key dependencies: System, System.Collections.Generic, Max.Bot.Types.Enums
// СЂСџвЂ™РЋ Usage: Р СњР В°РЎРѓРЎвЂљРЎР‚Р С•Р в„–Р С”Р В° IUpdateHandler Р С—Р С•Р Р†Р ВµР Т‘Р ВµР Р…Р С‘РЎРЏ РЎвЂЎР ВµРЎР‚Р ВµР В· MaxBotOptions

using System;
using System.Collections.Generic;
using Max.Bot.Types.Enums;

namespace Max.Bot.Configuration;

/// <summary>
/// Defines dispatcher-level knobs inspired by Telegram.Bot and VkNet handler pipelines.
/// </summary>
public sealed class UpdateHandlingOptions
{
    /// <summary>
    /// Gets or sets the maximum number of updates that may be processed in parallel.
    /// </summary>
    public int MaxDegreeOfParallelism { get; set; } = Environment.ProcessorCount;

    /// <summary>
    /// Gets or sets a value indicating whether the dispatcher must preserve update ordering (uses sequential execution when true).
    /// </summary>
    public bool PreserveUpdateOrder { get; set; } = true;

    /// <summary>
    /// Gets or sets the timeout applied to a single handler invocation.
    /// </summary>
    public TimeSpan HandlerTimeout { get; set; } = TimeSpan.FromMinutes(1);

    /// <summary>
    /// Gets or sets a value indicating whether handler exceptions bubble up (causing retries) or are logged and swallowed.
    /// </summary>
    public bool PropagateHandlerExceptions { get; set; } = false;

    /// <summary>
    /// Gets or sets the optional list of user names allowed to trigger handlers (mirrors Telegram.Bot integration test filters).
    /// </summary>
    public ICollection<string> AllowedUsernames { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets the update types that should be dispatched.
    /// </summary>
    public ICollection<UpdateType> AllowedUpdateTypes { get; set; } = new List<UpdateType>();

    /// <summary>
    /// Validates option values.
    /// </summary>
    public void Validate()
    {
        if (MaxDegreeOfParallelism < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(MaxDegreeOfParallelism), MaxDegreeOfParallelism, "MaxDegreeOfParallelism must be at least 1.");
        }

        if (HandlerTimeout <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(HandlerTimeout), HandlerTimeout, "HandlerTimeout must be greater than zero.");
        }

        if (AllowedUsernames is null)
        {
            throw new ArgumentNullException(nameof(AllowedUsernames), "AllowedUsernames cannot be null. Use an empty array to disable filtering.");
        }

        if (AllowedUpdateTypes is null)
        {
            throw new ArgumentNullException(nameof(AllowedUpdateTypes), "AllowedUpdateTypes cannot be null. Use an empty array to disable filtering.");
        }
    }
}



