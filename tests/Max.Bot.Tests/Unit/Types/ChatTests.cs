// 📁 [ChatTests] - Тесты для Chat модели
// 🎯 Core function: Тестирование сериализации/десериализации Chat
// 🔗 Key dependencies: Max.Bot.Types, Max.Bot.Networking, Max.Bot.Types.Enums, FluentAssertions, xUnit
// 💡 Usage: Unit тесты для проверки корректности работы Chat

using FluentAssertions;
using Max.Bot.Networking;
using Max.Bot.Types;
using Max.Bot.Types.Enums;
using Xunit;

namespace Max.Bot.Tests.Unit.Types;

public class ChatTests
{
    [Fact]
    public void Deserialize_ShouldDeserializeChat()
    {
        // Arrange
        var json = """{"id":123,"type":"private","title":"Test Chat","username":"testchat","firstName":"Test","lastName":"Chat"}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<Chat>(json);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(123);
        result.Type.Should().Be(ChatType.Private);
        result.Title.Should().Be("Test Chat");
        result.Username.Should().Be("testchat");
        result.FirstName.Should().Be("Test");
        result.LastName.Should().Be("Chat");
    }

    [Fact]
    public void Deserialize_ShouldDeserializeChatWithDifferentTypes()
    {
        // Arrange
        var testCases = new[]
        {
            ("""{"id":123,"type":"private"}""", ChatType.Private),
            ("""{"id":456,"type":"group","title":"Group Chat"}""", ChatType.Group),
            ("""{"id":789,"type":"channel","title":"Channel Chat"}""", ChatType.Channel)
        };

        // Act & Assert
        foreach (var (json, expectedType) in testCases)
        {
            var result = MaxJsonSerializer.Deserialize<Chat>(json);
            result.Should().NotBeNull();
            result!.Type.Should().Be(expectedType);
        }
    }

    [Fact]
    public void Serialize_ShouldSerializeChat()
    {
        // Arrange
        var chat = new Chat
        {
            Id = 123,
            Type = ChatType.Private,
            Title = "Test Chat",
            Username = "testchat"
        };

        // Act
        var json = MaxJsonSerializer.Serialize(chat);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("\"id\":123");
        json.Should().Contain("\"type\":\"private\"");
        json.Should().Contain("\"title\":\"Test Chat\"");
        json.Should().Contain("\"username\":\"testchat\"");
    }

    [Fact]
    public void Serialize_ShouldNotIncludeNullFields()
    {
        // Arrange
        var chat = new Chat
        {
            Id = 123,
            Type = ChatType.Private
        };

        // Act
        var json = MaxJsonSerializer.Serialize(chat);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("\"id\":123");
        json.Should().Contain("\"type\":\"private\"");
        json.Should().NotContain("\"title\"");
        json.Should().NotContain("\"username\"");
    }
}

