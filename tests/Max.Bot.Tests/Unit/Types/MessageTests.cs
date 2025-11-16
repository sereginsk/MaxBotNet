// 📁 [MessageTests] - Тесты для Message модели
// 🎯 Core function: Тестирование сериализации/десериализации Message
// 🔗 Key dependencies: Max.Bot.Types, Max.Bot.Networking, Max.Bot.Types.Enums, FluentAssertions, xUnit
// 💡 Usage: Unit тесты для проверки корректности работы Message

using FluentAssertions;
using Max.Bot.Networking;
using Max.Bot.Types;
using Max.Bot.Types.Enums;
using Xunit;

namespace Max.Bot.Tests.Unit.Types;

public class MessageTests
{
    [Fact]
    public void Deserialize_ShouldDeserializeMessage()
    {
        // Arrange
        var json = """{"id":123,"chat":{"id":456,"type":"private"},"from":{"id":789,"username":"testuser","isBot":false},"text":"Hello","date":1609459200,"type":"text"}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<Message>(json);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(123);
        result.Chat.Should().NotBeNull();
        result.Chat!.Id.Should().Be(456);
        result.Chat.Type.Should().Be(ChatType.Private);
        result.From.Should().NotBeNull();
        result.From!.Id.Should().Be(789);
        result.From.Username.Should().Be("testuser");
        result.Text.Should().Be("Hello");
        result.Date.Should().BeCloseTo(new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc), TimeSpan.FromSeconds(1));
        result.Type.Should().Be(MessageType.Text);
    }

    [Fact]
    public void Deserialize_ShouldDeserializeMessageWithNullFields()
    {
        // Arrange
        var json = """{"id":123,"date":1609459200}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<Message>(json);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(123);
        result.Chat.Should().BeNull();
        result.From.Should().BeNull();
        result.Text.Should().BeNull();
        result.Type.Should().BeNull();
    }

    [Fact]
    public void Serialize_ShouldSerializeMessage()
    {
        // Arrange
        var message = new Message
        {
            Id = 123,
            Chat = new Chat { Id = 456, Type = ChatType.Private },
            From = new User { Id = 789, Username = "testuser" },
            Text = "Hello",
            Date = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            Type = MessageType.Text
        };

        // Act
        var json = MaxJsonSerializer.Serialize(message);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("\"id\":123");
        json.Should().Contain("\"chat\"");
        json.Should().Contain("\"from\"");
        json.Should().Contain("\"text\":\"Hello\"");
        json.Should().Contain("\"date\":1609459200");
        json.Should().Contain("\"type\":\"text\"");
    }

    [Fact]
    public void Serialize_ShouldNotIncludeNullFields()
    {
        // Arrange
        var message = new Message
        {
            Id = 123,
            Date = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        };

        // Act
        var json = MaxJsonSerializer.Serialize(message);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("\"id\":123");
        json.Should().Contain("\"date\":1609459200");
        json.Should().NotContain("\"chat\"");
        json.Should().NotContain("\"from\"");
        json.Should().NotContain("\"text\"");
        json.Should().NotContain("\"type\"");
    }
}

