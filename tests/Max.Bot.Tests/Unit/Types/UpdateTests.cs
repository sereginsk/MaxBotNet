// 📁 [UpdateTests] - Тесты для Update модели
// 🎯 Core function: Тестирование сериализации/десериализации Update
// 🔗 Key dependencies: Max.Bot.Types, Max.Bot.Networking, Max.Bot.Types.Enums, FluentAssertions, xUnit
// 💡 Usage: Unit тесты для проверки корректности работы Update

using FluentAssertions;
using Max.Bot.Networking;
using Max.Bot.Types;
using Max.Bot.Types.Enums;
using Xunit;

namespace Max.Bot.Tests.Unit.Types;

public class UpdateTests
{
    [Fact]
    public void Deserialize_ShouldDeserializeUpdateWithMessage()
    {
        // Arrange
        var json = """{"updateId":1,"type":"message","message":{"id":123,"chat":{"id":456,"type":"private"},"from":{"id":789,"username":"testuser","isBot":false},"text":"Hello","date":1609459200}}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<Update>(json);

        // Assert
        result.Should().NotBeNull();
        result!.UpdateId.Should().Be(1);
        result.Type.Should().Be(UpdateType.Message);
        result.Message.Should().NotBeNull();
        result.Message!.Id.Should().Be(123);
        result.Message.Text.Should().Be("Hello");
    }

    [Fact]
    public void Deserialize_ShouldDeserializeUpdateWithCallbackQuery()
    {
        // Arrange
        var json = """{"updateId":2,"type":"callback_query","message":null}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<Update>(json);

        // Assert
        result.Should().NotBeNull();
        result!.UpdateId.Should().Be(2);
        result.Type.Should().Be(UpdateType.CallbackQuery);
        result.Message.Should().BeNull();
    }

    [Fact]
    public void Serialize_ShouldSerializeUpdate()
    {
        // Arrange
        var update = new Update
        {
            UpdateId = 1,
            Type = UpdateType.Message,
            Message = new Message
            {
                Id = 123,
                Text = "Hello",
                Date = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        };

        // Act
        var json = MaxJsonSerializer.Serialize(update);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("\"updateId\":1");
        json.Should().Contain("\"type\":\"message\"");
        json.Should().Contain("\"message\"");
        json.Should().Contain("\"id\":123");
    }

    [Fact]
    public void Serialize_ShouldNotIncludeNullMessage()
    {
        // Arrange
        var update = new Update
        {
            UpdateId = 2,
            Type = UpdateType.CallbackQuery,
            Message = null
        };

        // Act
        var json = MaxJsonSerializer.Serialize(update);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("\"updateId\":2");
        json.Should().Contain("\"type\":\"callback_query\"");
        json.Should().NotContain("\"message\"");
    }
}

