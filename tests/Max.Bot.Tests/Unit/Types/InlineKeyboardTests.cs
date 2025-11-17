// СЂСџвЂњРѓ [InlineKeyboardTests] - Р СћР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ Р СР С•Р Т‘Р ВµР В»Р С‘ InlineKeyboard
// СЂСџР‹Р‡ Core function: Р СћР ВµРЎРѓРЎвЂљР С‘РЎР‚Р С•Р Р†Р В°Р Р…Р С‘Р Вµ РЎРѓР ВµРЎР‚Р С‘Р В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘/Р Т‘Р ВµРЎРѓР ВµРЎР‚Р С‘Р В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘ InlineKeyboard
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Types, Max.Bot.Networking, FluentAssertions, xUnit
// СЂСџвЂ™РЋ Usage: Unit РЎвЂљР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ Р С—РЎР‚Р С•Р Р†Р ВµРЎР‚Р С”Р С‘ Р С”Р С•РЎР‚РЎР‚Р ВµР С”РЎвЂљР Р…Р С•РЎРѓРЎвЂљР С‘ РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ Р СР С•Р Т‘Р ВµР В»Р С‘ InlineKeyboard

using FluentAssertions;
using Max.Bot.Networking;
using Max.Bot.Types;
using Xunit;

namespace Max.Bot.Tests.Unit.Types;

public class InlineKeyboardTests
{
    [Fact]
    public void InlineKeyboard_ShouldDeserialize_FromJson()
    {
        // Arrange
        var json = """{"inline_keyboard":[[{"text":"Button 1","callback_data":"callback1"}],[{"text":"Button 2","url":"https://example.com"}]]}""";

        // Act
        var keyboard = MaxJsonSerializer.Deserialize<InlineKeyboard>(json);

        // Assert
        keyboard.Should().NotBeNull();
        keyboard.Buttons.Should().HaveCount(2);
        keyboard.Buttons[0].Should().HaveCount(1);
        keyboard.Buttons[0][0].Text.Should().Be("Button 1");
        keyboard.Buttons[0][0].CallbackData.Should().Be("callback1");
        keyboard.Buttons[1].Should().HaveCount(1);
        keyboard.Buttons[1][0].Text.Should().Be("Button 2");
        keyboard.Buttons[1][0].Url.Should().Be("https://example.com");
    }

    [Fact]
    public void InlineKeyboard_ShouldDeserialize_WithEmptyButtons()
    {
        // Arrange
        var json = """{"inline_keyboard":[]}""";

        // Act
        var keyboard = MaxJsonSerializer.Deserialize<InlineKeyboard>(json);

        // Assert
        keyboard.Should().NotBeNull();
        keyboard.Buttons.Should().BeEmpty();
    }

    [Fact]
    public void InlineKeyboard_ShouldSerialize_ToJson()
    {
        // Arrange
        var keyboard = new InlineKeyboard
        {
            Buttons = new[]
            {
                new[]
                {
                    new InlineKeyboardButton { Text = "Button 1", CallbackData = "callback1" }
                },
                new[]
                {
                    new InlineKeyboardButton { Text = "Button 2", Url = "https://example.com" }
                }
            }
        };

        // Act
        var json = MaxJsonSerializer.Serialize(keyboard);

        // Assert
        json.Should().Contain("\"inline_keyboard\"");
        json.Should().Contain("\"text\":\"Button 1\"");
        json.Should().Contain("\"callback_data\":\"callback1\"");
        json.Should().Contain("\"text\":\"Button 2\"");
        json.Should().Contain("\"url\":\"https://example.com\"");
    }

    [Fact]
    public void InlineKeyboard_ShouldSerialize_WithEmptyButtons()
    {
        // Arrange
        var keyboard = new InlineKeyboard
        {
            Buttons = Array.Empty<InlineKeyboardButton[]>()
        };

        // Act
        var json = MaxJsonSerializer.Serialize(keyboard);

        // Assert
        json.Should().Contain("\"inline_keyboard\":[]");
    }
}

