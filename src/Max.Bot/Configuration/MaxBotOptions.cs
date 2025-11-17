// СЂСџвЂњРѓ [MaxBotOptions] - Р вЂР В°Р В·Р С•Р Р†РЎвЂ№Р Вµ Р С•Р С—РЎвЂ Р С‘Р С‘ Р В±Р С•РЎвЂљР В° Max Messenger
// СЂСџР‹Р‡ Core function: Р С™Р С•Р Р…РЎвЂћР С‘Р С–РЎС“РЎР‚Р В°РЎвЂ Р С‘РЎРЏ Р В±Р С•РЎвЂљР В° (РЎвЂљР С•Р С”Р ВµР Р…, Р В±Р В°Р В·Р С•Р Р†РЎвЂ№Р в„– URL API)
// СЂСџвЂќвЂ” Key dependencies: System
// СЂСџвЂ™РЋ Usage: Р СњР В°РЎРѓРЎвЂљРЎР‚Р С•Р в„–Р С”Р В° MaxClient РЎвЂЎР ВµРЎР‚Р ВµР В· MaxBotOptions Р Т‘Р В»РЎРЏ РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ РЎРѓ Max Messenger Bot API

using System;

namespace Max.Bot.Configuration;

/// <summary>
/// Options for configuring the Max Bot client.
/// </summary>
public class MaxBotOptions
{
    /// <summary>
    /// Gets or sets the bot token for authentication.
    /// </summary>
    /// <value>The bot token. Must not be null or empty.</value>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the base URL of the Max Bot API.
    /// </summary>
    /// <value>The base URL of the API. Default is "https://api.max.ru/bot".</value>
    public string BaseUrl { get; set; } = "https://api.max.ru/bot";

    /// <summary>
    /// Gets or sets polling-specific settings that map to <c>GET /updates</c> parameters described in the MAX docs.
    /// </summary>
    public MaxPollingOptions Polling { get; set; } = new();

    /// <summary>
    /// Gets or sets webhook settings aligned with <c>POST/DELETE /subscriptions</c>.
    /// </summary>
    public MaxWebhookOptions Webhook { get; set; } = new();

    /// <summary>
    /// Gets or sets dispatcher-level options inspired by Telegram.Bot handler design.
    /// </summary>
    public UpdateHandlingOptions Handling { get; set; } = new();

    /// <summary>
    /// Validates the options.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when Token or BaseUrl is null or empty, or BaseUrl is not a valid URI.</exception>
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Token))
        {
            throw new ArgumentException("Token cannot be null or empty.", nameof(Token));
        }

        if (string.IsNullOrWhiteSpace(BaseUrl))
        {
            throw new ArgumentException("BaseUrl cannot be null or empty.", nameof(BaseUrl));
        }

        if (!Uri.TryCreate(BaseUrl, UriKind.Absolute, out var uri) || !uri.IsAbsoluteUri)
        {
            throw new ArgumentException("BaseUrl must be a valid absolute URI.", nameof(BaseUrl));
        }

        // Validate that the URI scheme is HTTP or HTTPS
        if (!uri.Scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) &&
            !uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("BaseUrl must use HTTP or HTTPS scheme.", nameof(BaseUrl));
        }

        Polling ??= new MaxPollingOptions();
        Polling.Validate();

        Webhook ??= new MaxWebhookOptions();
        Webhook.Validate();

        Handling ??= new UpdateHandlingOptions();
        Handling.Validate();
    }
}


