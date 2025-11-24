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
        var json = """{"update_id":1,"update_type":"message_created","message":{"id":123,"chat":{"id":456,"type":"private"},"from":{"user_id":789,"username":"testuser","is_bot":false},"text":"Hello","date":1609459200}}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<Update>(json);

        // Assert
        result.Should().NotBeNull();
        result!.UpdateId.Should().Be(1);
        result.Type.Should().Be(UpdateType.Message);
        result.Message.Should().NotBeNull();
        result.Message!.Id.Should().Be(123);
        result.Message.Text.Should().Be("Hello");
        
        // Test typed wrapper
        result.MessageUpdate.Should().NotBeNull();
        result.MessageUpdate!.UpdateId.Should().Be(1);
        result.MessageUpdate.Message.Should().NotBeNull();
        result.MessageUpdate.Message.Id.Should().Be(123);
        result.MessageUpdate.Message.Text.Should().Be("Hello");
    }

    [Fact]
    public void Deserialize_ShouldDeserializeUpdateWithCallbackQuery()
    {
        // Arrange
        var json = """{"update_id":2,"update_type":"message_callback","callback_query":{"id":"callback123","from":{"user_id":123,"username":"user123","is_bot":false},"data":"callbackData123"}}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<Update>(json);

        // Assert
        result.Should().NotBeNull();
        result!.UpdateId.Should().Be(2);
        result.Type.Should().Be(UpdateType.CallbackQuery);
        result.CallbackQuery.Should().NotBeNull();
        result.CallbackQuery!.Id.Should().Be("callback123");
        result.CallbackQuery.From.Id.Should().Be(123);
        result.CallbackQuery.Data.Should().Be("callbackData123");
        
        // Test typed wrapper
        result.CallbackQueryUpdate.Should().NotBeNull();
        result.CallbackQueryUpdate!.UpdateId.Should().Be(2);
        result.CallbackQueryUpdate.CallbackQuery.Should().NotBeNull();
        result.CallbackQueryUpdate.CallbackQuery.Id.Should().Be("callback123");
        result.CallbackQueryUpdate.CallbackQuery.From.Id.Should().Be(123);
        result.CallbackQueryUpdate.CallbackQuery.Data.Should().Be("callbackData123");
    }

    [Fact]
    public void Serialize_ShouldSerializeUpdate()
    {
        // Arrange
        var update = new Update
        {
            UpdateId = 1,
            UpdateTypeRaw = "message_created",
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
        json.Should().Contain("\"update_id\":1");
        json.Should().Contain("\"update_type\":\"message_created\"");
        json.Should().Contain("\"message\"");
        json.Should().Contain("\"id\":123");
    }

    [Fact]
    public void Serialize_ShouldSerializeUpdateWithCallbackQuery()
    {
        // Arrange
        var update = new Update
        {
            UpdateId = 2,
            UpdateTypeRaw = "message_callback",
            CallbackQuery = new CallbackQuery
            {
                Id = "callback123",
                From = new User { Id = 123, Username = "user123", IsBot = false },
                Data = "callbackData123"
            }
        };

        // Act
        var json = MaxJsonSerializer.Serialize(update);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("\"update_id\":2");
        json.Should().Contain("\"update_type\":\"message_callback\"");
        json.Should().Contain("\"callback_query\"");
        json.Should().Contain("\"id\":\"callback123\"");
    }

    [Fact]
    public void Serialize_ShouldNotIncludeNullMessage()
    {
        // Arrange
        var update = new Update
        {
            UpdateId = 2,
            UpdateTypeRaw = "message_callback",
            Message = null,
            CallbackQuery = null
        };

        // Act
        var json = MaxJsonSerializer.Serialize(update);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("\"update_id\":2");
        json.Should().Contain("\"update_type\":\"message_callback\"");
        json.Should().NotContain("\"message\"");
        json.Should().NotContain("\"callback_query\"");
    }

    [Fact]
    public void Deserialize_ShouldDeserializeWebhookUpdateWithoutMessageId()
    {
        // Arrange - формат вебхука без message.id, только body.mid
        var json = """{"message":{"recipient":{"chat_id":79313411,"chat_type":"dialog","user_id":94399782},"timestamp":1763928007254,"body":{"mid":"mid.0000000004ba3a03019ab24d62566a52","seq":115600785883425360,"text":"/start"},"sender":{"user_id":18503461,"first_name":"Александр","last_name":"Сюзев","is_bot":false,"last_activity_time":1763927992000,"name":"Александр Сюзев"}},"timestamp":1763928007254,"user_locale":"ru","update_type":"message_created"}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<Update>(json);

        // Assert
        result.Should().NotBeNull();
        result!.UpdateTypeRaw.Should().Be("message_created");
        result.Type.Should().Be(UpdateType.Message);
        result.Message.Should().NotBeNull();
        result.Message!.Id.Should().BeNull(); // ID отсутствует в JSON
        result.Message.Body.Should().NotBeNull();
        result.Message.Body!.Mid.Should().Be("mid.0000000004ba3a03019ab24d62566a52");
        result.Message.Body.Text.Should().Be("/start");
        result.Message.Sender.Should().NotBeNull();
        result.Message.Sender!.Id.Should().Be(18503461);
        result.Message.Recipient.Should().NotBeNull();
        result.Message.Recipient!.ChatId.Should().Be(79313411);
        
        // Test typed wrapper
        result.MessageUpdate.Should().NotBeNull();
        result.MessageUpdate!.Timestamp.Should().Be(1763928007254);
        result.MessageUpdate.UserLocale.Should().Be("ru");
        result.MessageUpdate.Message.Should().NotBeNull();
        result.MessageUpdate.Message.Body.Should().NotBeNull();
        result.MessageUpdate.Message.Body!.Mid.Should().Be("mid.0000000004ba3a03019ab24d62566a52");
    }

    [Fact]
    public void MessageUpdate_ShouldContainAllUpdateFields()
    {
        // Arrange
        var json = """{"update_id":100,"update_type":"message_created","timestamp":1609459200000,"user_locale":"en","message":{"id":123,"text":"Test","date":1609459200}}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<Update>(json);

        // Assert
        result.Should().NotBeNull();
        result!.MessageUpdate.Should().NotBeNull();
        result.MessageUpdate!.UpdateId.Should().Be(100);
        result.MessageUpdate.Timestamp.Should().Be(1609459200000);
        result.MessageUpdate.UserLocale.Should().Be("en");
        result.MessageUpdate.Message.Should().NotBeNull();
        result.MessageUpdate.Message.Id.Should().Be(123);
    }

    [Fact]
    public void CallbackQueryUpdate_ShouldContainAllUpdateFields()
    {
        // Arrange
        var json = """{"update_id":200,"update_type":"message_callback","timestamp":1609459200000,"user_locale":"ru","callback_query":{"id":"cb123","from":{"user_id":456,"username":"test","is_bot":false},"data":"data123"}}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<Update>(json);

        // Assert
        result.Should().NotBeNull();
        result!.CallbackQueryUpdate.Should().NotBeNull();
        result.CallbackQueryUpdate!.UpdateId.Should().Be(200);
        result.CallbackQueryUpdate.Timestamp.Should().Be(1609459200000);
        result.CallbackQueryUpdate.UserLocale.Should().Be("ru");
        result.CallbackQueryUpdate.CallbackQuery.Should().NotBeNull();
        result.CallbackQueryUpdate.CallbackQuery.Id.Should().Be("cb123");
    }

    [Fact]
    public void BackwardCompatibility_MessagePropertyShouldWork()
    {
        // Arrange
        var json = """{"update_id":1,"update_type":"message_created","message":{"id":123,"text":"Hello","date":1609459200}}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<Update>(json);

        // Assert - old property should still work
        result.Should().NotBeNull();
        result!.Message.Should().NotBeNull();
        result.Message!.Id.Should().Be(123);
        result.Message.Text.Should().Be("Hello");
        
        // Both old and new should reference the same object
        result.Message.Should().BeSameAs(result.MessageUpdate!.Message);
    }

    [Fact]
    public void BackwardCompatibility_CallbackQueryPropertyShouldWork()
    {
        // Arrange
        var json = """{"update_id":2,"update_type":"message_callback","callback_query":{"id":"cb123","from":{"user_id":123,"username":"test","is_bot":false},"data":"data123"}}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<Update>(json);

        // Assert - old property should still work
        result.Should().NotBeNull();
        result!.CallbackQuery.Should().NotBeNull();
        result.CallbackQuery!.Id.Should().Be("cb123");
        result.CallbackQuery.Data.Should().Be("data123");
        
        // Both old and new should reference the same object
        result.CallbackQuery.Should().BeSameAs(result.CallbackQueryUpdate!.CallbackQuery);
    }
}

