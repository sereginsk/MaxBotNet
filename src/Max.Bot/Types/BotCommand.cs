using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Max.Bot.Types;

/// <summary>
/// Represents a bot command that appears in the command menu.
/// </summary>
public class BotCommand
{
    /// <summary>
    /// Gets or sets the command name (without leading slash).
    /// </summary>
    /// <value>The command name, e.g., "start", "help".</value>
    [Required(ErrorMessage = "Command name is required.")]
    [StringLength(64, MinimumLength = 1, ErrorMessage = "Command name must be between 1 and 64 characters.")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the command description shown in the menu.
    /// </summary>
    /// <value>The description of what the command does.</value>
    [Required(ErrorMessage = "Command description is required.")]
    [StringLength(256, MinimumLength = 1, ErrorMessage = "Command description must be between 1 and 256 characters.")]
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="BotCommand"/> class.
    /// </summary>
    public BotCommand()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BotCommand"/> class with specified name and description.
    /// </summary>
    /// <param name="name">The command name (without leading slash).</param>
    /// <param name="description">The command description.</param>
    public BotCommand(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

