using FluentAssertions;
using Max.Bot.Networking;
using Max.Bot.Types;
using Xunit;

namespace Max.Bot.Tests.Unit.Types;

public class BotCommandTests
{
    [Fact]
    public void BotCommand_ShouldInitialize_WithDefaultConstructor()
    {
        // Act
        var command = new BotCommand();

        // Assert
        command.Name.Should().BeEmpty();
        command.Description.Should().BeEmpty();
    }

    [Fact]
    public void BotCommand_ShouldInitialize_WithParameterizedConstructor()
    {
        // Act
        var command = new BotCommand("start", "Start the bot");

        // Assert
        command.Name.Should().Be("start");
        command.Description.Should().Be("Start the bot");
    }

    [Fact]
    public void BotCommand_ShouldSerialize_ToJson()
    {
        // Arrange
        var command = new BotCommand("help", "Show help message");

        // Act
        var json = MaxJsonSerializer.Serialize(command);

        // Assert
        json.Should().Contain("\"name\":\"help\"");
        json.Should().Contain("\"description\":\"Show help message\"");
    }

    [Fact]
    public void BotCommand_ShouldDeserialize_FromJson()
    {
        // Arrange
        var json = """{"name":"settings","description":"Open settings"}""";

        // Act
        var command = MaxJsonSerializer.Deserialize<BotCommand>(json);

        // Assert
        command.Should().NotBeNull();
        command.Name.Should().Be("settings");
        command.Description.Should().Be("Open settings");
    }

    [Fact]
    public void BotCommand_ShouldSerializeAndDeserialize_Roundtrip()
    {
        // Arrange
        var original = new BotCommand("test", "Test command");

        // Act
        var json = MaxJsonSerializer.Serialize(original);
        var deserialized = MaxJsonSerializer.Deserialize<BotCommand>(json);

        // Assert
        deserialized.Should().NotBeNull();
        deserialized.Name.Should().Be(original.Name);
        deserialized.Description.Should().Be(original.Description);
    }

    [Fact]
    public void BotCommand_ShouldSerialize_WithCyrillicCharacters()
    {
        // Arrange
        var command = new BotCommand("start", "Начать работу с ботом");

        // Act
        var json = MaxJsonSerializer.Serialize(command);
        var deserialized = MaxJsonSerializer.Deserialize<BotCommand>(json);

        // Assert
        deserialized.Should().NotBeNull();
        deserialized.Name.Should().Be("start");
        deserialized.Description.Should().Be("Начать работу с ботом");
    }

    [Fact]
    public void BotCommandArray_ShouldSerialize_ToJson()
    {
        // Arrange
        var commands = new[]
        {
            new BotCommand("start", "Старт"),
            new BotCommand("help", "Помощь"),
            new BotCommand("settings", "Настройки")
        };

        // Act
        var json = MaxJsonSerializer.Serialize(commands);

        // Assert
        json.Should().Contain("\"name\":\"start\"");
        json.Should().Contain("\"name\":\"help\"");
        json.Should().Contain("\"name\":\"settings\"");
    }

    [Fact]
    public void BotCommandArray_ShouldDeserialize_FromJson()
    {
        // Arrange
        var json = """[{"name":"start","description":"Старт"},{"name":"help","description":"Помощь"}]""";

        // Act
        var commands = MaxJsonSerializer.Deserialize<BotCommand[]>(json);

        // Assert
        commands.Should().NotBeNull();
        commands.Should().HaveCount(2);
        commands![0].Name.Should().Be("start");
        commands[0].Description.Should().Be("Старт");
        commands[1].Name.Should().Be("help");
        commands[1].Description.Should().Be("Помощь");
    }
}

