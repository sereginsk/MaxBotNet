// СЂСџвЂњРѓ [UpdateContext] - Р С™Р С•Р Р…РЎвЂљР ВµР С”РЎРѓРЎвЂљ Р С—Р ВµРЎР‚Р ВµР Т‘Р В°РЎвЂЎР С‘ Р С•Р В±Р Р…Р С•Р Р†Р В»Р ВµР Р…Р С‘РЎРЏ Р С•Р В±РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂЎР С‘Р С”РЎС“
// СЂСџР‹Р‡ Core function: Р ВР Р…Р С”Р В°Р С—РЎРѓРЎС“Р В»Р С‘РЎР‚РЎС“Р ВµРЎвЂљ Update, API, Р С•Р С—РЎвЂ Р С‘Р С‘ Р С‘ РЎРѓР ВµРЎР‚Р Р†Р С‘РЎРѓРЎвЂ№
// СЂСџвЂќвЂ” Key dependencies: System, System.Collections.Generic, Microsoft.Extensions.Logging, Max.Bot.Api, Max.Bot.Configuration, Max.Bot.Types
// СЂСџвЂ™РЋ Usage: Р СџР ВµРЎР‚Р ВµР Т‘Р В°Р ВµРЎвЂљРЎРѓРЎРЏ Р Р† IUpdateHandler Р Т‘Р В»РЎРЏ Р С•Р В±РЎР‚Р В°Р В±Р С•РЎвЂљР С”Р С‘ РЎРѓР С•Р В±РЎвЂ№РЎвЂљР С‘Р в„–

using System;
using System.Collections.Generic;
using Max.Bot.Api;
using Max.Bot.Configuration;
using Max.Bot.Types;
using Microsoft.Extensions.Logging;

namespace Max.Bot.Polling;

/// <summary>
/// Represents the immutable context that accompanies each update dispatch.
/// </summary>
public sealed class UpdateContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateContext"/> class.
    /// </summary>
    /// <param name="update">The update payload supplied by the MAX API.</param>
    /// <param name="api">The API surface (typically <see cref="Max.Bot.MaxClient"/>) for executing follow-up calls.</param>
    /// <param name="options">Snapshot of <see cref="MaxBotOptions"/> used when the poller/webhook was created.</param>
    /// <param name="logger">Optional logger scoped to the poller or webhook pipeline.</param>
    /// <param name="services">Optional service provider for resolving user dependencies.</param>
    public UpdateContext(Update update, IMaxBotApi api, MaxBotOptions options, ILogger? logger = null, IServiceProvider? services = null)
    {
        Update = update ?? throw new ArgumentNullException(nameof(update));
        Api = api ?? throw new ArgumentNullException(nameof(api));
        Options = options ?? throw new ArgumentNullException(nameof(options));
        Logger = logger;
        Services = services;
        ReceivedAt = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Gets the update.
    /// </summary>
    public Update Update { get; }

    /// <summary>
    /// Gets the API surface for follow-up calls inside handlers.
    /// </summary>
    public IMaxBotApi Api { get; }

    /// <summary>
    /// Gets the options snapshot.
    /// </summary>
    public MaxBotOptions Options { get; }

    /// <summary>
    /// Gets the logger scoped to the dispatcher.
    /// </summary>
    public ILogger? Logger { get; }

    /// <summary>
    /// Gets the service provider (if the host application supplied one).
    /// </summary>
    public IServiceProvider? Services { get; }

    /// <summary>
    /// Gets the UTC timestamp recorded when the update entered the pipeline.
    /// </summary>
    public DateTimeOffset ReceivedAt { get; }

    /// <summary>
    /// Gets the bag for storing arbitrary data during handler execution.
    /// </summary>
    public IDictionary<string, object?> Items { get; } = new Dictionary<string, object?>(StringComparer.Ordinal);
}




