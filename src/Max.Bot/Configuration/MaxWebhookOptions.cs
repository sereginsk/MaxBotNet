// СЂСџвЂњРѓ [MaxWebhookOptions] - Р СњР В°РЎРѓРЎвЂљРЎР‚Р С•Р в„–Р С”Р С‘ Webhook Р С—Р С•Р Т‘Р С—Р С‘РЎРѓР С•Р С” MAX
// СЂСџР‹Р‡ Core function: Р Р€Р С—РЎР‚Р В°Р Р†Р В»РЎРЏР ВµРЎвЂљ POST/DELETE /subscriptions Р С‘ Webhook Р С—РЎР‚Р С•Р Р†Р ВµРЎР‚Р С”Р В°Р СР С‘
// СЂСџвЂќвЂ” Key dependencies: System
// СЂСџвЂ™РЋ Usage: Р С™Р С•Р Р…РЎвЂћР С‘Р С–РЎС“РЎР‚Р В°РЎвЂ Р С‘РЎРЏ MaxClient webhook Р С•Р В±РЎР‚Р В°Р В±Р С•РЎвЂљР С”Р С‘ Р С‘ Р В±Р ВµР В·Р С•Р С—Р В°РЎРѓР Р…Р С•РЎРѓРЎвЂљР С‘

using System;

namespace Max.Bot.Configuration;

/// <summary>
/// Describes webhook subscription preferences following the guidance from https://dev.max.ru/docs-api/methods/POST/subscriptions.
/// </summary>
public sealed class MaxWebhookOptions
{
    /// <summary>
    /// Gets or sets the public HTTPS endpoint that MAX should call (maps to subscription <c>url</c> payload).
    /// </summary>
    public string? Endpoint { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether HTTPS is mandatory for <see cref="Endpoint"/>.
    /// </summary>
    public bool EnforceHttps { get; set; } = true;

    /// <summary>
    /// Gets or sets the shared secret MAX will include in webhook requests (recommended by Telegram/Vk best practices).
    /// </summary>
    public string? SecretToken { get; set; }

    /// <summary>
    /// Gets or sets the header name storing the webhook signature or secret token.
    /// </summary>
    public string SignatureHeaderName { get; set; } = "X-Max-Signature";

    /// <summary>
    /// Gets or sets the maximum accepted request body size for webhook payloads (in KiB).
    /// </summary>
    public int MaxBodySizeKilobytes { get; set; } = 512;

    /// <summary>
    /// Gets or sets the per-request execution timeout applied while dispatching updates.
    /// </summary>
    public TimeSpan HandlerTimeout { get; set; } = TimeSpan.FromSeconds(30);

    /// <summary>
    /// Gets or sets a value indicating whether every subscription change must be confirmed with MAX via POST/DELETE /subscriptions.
    /// </summary>
    public bool RequireSubscriptionConfirmation { get; set; } = true;

    /// <summary>
    /// Validates option values.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when configuration is invalid.</exception>
    public void Validate()
    {
        if (!string.IsNullOrWhiteSpace(Endpoint))
        {
            if (!Uri.TryCreate(Endpoint, UriKind.Absolute, out var uri))
            {
                throw new ArgumentException("Endpoint must be a valid absolute URI.", nameof(Endpoint));
            }

            if (EnforceHttps && !Uri.UriSchemeHttps.Equals(uri.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Endpoint must use HTTPS when EnforceHttps is enabled.", nameof(Endpoint));
            }
        }

        if (MaxBodySizeKilobytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(MaxBodySizeKilobytes), MaxBodySizeKilobytes, "MaxBodySizeKilobytes must be greater than zero.");
        }

        if (HandlerTimeout <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(HandlerTimeout), HandlerTimeout, "HandlerTimeout must be greater than zero.");
        }

        if (string.IsNullOrWhiteSpace(SignatureHeaderName))
        {
            throw new ArgumentException("SignatureHeaderName cannot be null or whitespace.", nameof(SignatureHeaderName));
        }
    }
}




