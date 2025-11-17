// СЂСџвЂњРѓ [InlineKeyboardButtonTests] - Р СћР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ Р СР С•Р Т‘Р ВµР В»Р С‘ InlineKeyboardButton
// СЂСџР‹Р‡ Core function: Р СћР ВµРЎРѓРЎвЂљР С‘РЎР‚Р С•Р Р†Р В°Р Р…Р С‘Р Вµ РЎРѓР ВµРЎР‚Р С‘Р В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘/Р Т‘Р ВµРЎРѓР ВµРЎР‚Р С‘Р В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘ InlineKeyboardButton
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Types, Max.Bot.Networking, FluentAssertions, xUnit
// СЂСџвЂ™РЋ Usage: Unit РЎвЂљР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ Р С—РЎР‚Р С•Р Р†Р ВµРЎР‚Р С”Р С‘ Р С”Р С•РЎР‚РЎР‚Р ВµР С”РЎвЂљР Р…Р С•РЎРѓРЎвЂљР С‘ РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ Р СР С•Р Т‘Р ВµР В»Р С‘ InlineKeyboardButton

using FluentAssertions;
using Max.Bot.Networking;
using Max.Bot.Types;
using Xunit;

namespace Max.Bot.Tests.Unit.Types;

public class InlineKeyboardButtonTests
{
    [Fact]
    public void InlineKeyboardButton_ShouldDeserialize_FromJson_WithCallbackData()
    {
        // Arrange
        var json = """{"text":"Button Text","callbackData":"callback123"}""";

        // Act
        var button = MaxJsonSerializer.Deserialize<InlineKeyboardButton>(json);

        // Assert
        button.Should().NotBeNull();
        button.Text.Should().Be("Button Text");
        button.CallbackData.Should().Be("callback123");
        button.Url.Should().BeNull();
    }

    [Fact]
    public void InlineKeyboardButton_ShouldDeserialize_FromJson_WithUrl()
    {
        // Arrange
        var json = """{"text":"Open URL","url":"https://example.com"}""";

        // Act
        var button = MaxJsonSerializer.Deserialize<InlineKeyboardButton>(json);

        // Assert
        button.Should().NotBeNull();
        button.Text.Should().Be("Open URL");
        button.Url.Should().Be("https://example.com");
        button.CallbackData.Should().BeNull();
    }

    [Fact]
    public void InlineKeyboardButton_ShouldSerialize_ToJson()
    {
        // Arrange
        var button = new InlineKeyboardButton
        {
            Text = "Button Text",
            CallbackData = "callback123"
        };

        // Act
        var json = MaxJsonSerializer.Serialize(button);

        // Assert
        json.Should().Contain("\"text\":\"Button Text\"");
        json.Should().Contain("\"callbackData\":\"callback123\"");
    }

    [Fact]
    public void InlineKeyboardButton_ShouldSerialize_WithUrl()
    {
        // Arrange
        var button = new InlineKeyboardButton
        {
            Text = "Open URL",
            Url = "https://example.com"
        };

        // Act
        var json = MaxJsonSerializer.Serialize(button);

        // Assert
        json.Should().Contain("\"text\":\"Open URL\"");
        json.Should().Contain("\"url\":\"https://example.com\"");
    }
}

