// 📁 [MaxBotOptions] - Базовые опции бота Max Messenger
// 🎯 Core function: Конфигурация бота (токен, базовый URL API)
// 🔗 Key dependencies: System
// 💡 Usage: Настройка MaxClient через MaxBotOptions для работы с Max Messenger Bot API

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
    }
}

