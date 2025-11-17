// СЂСџвЂњРѓ [UserTests] - Р СћР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ User Р СР С•Р Т‘Р ВµР В»Р С‘
// СЂСџР‹Р‡ Core function: Р СћР ВµРЎРѓРЎвЂљР С‘РЎР‚Р С•Р Р†Р В°Р Р…Р С‘Р Вµ РЎРѓР ВµРЎР‚Р С‘Р В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘/Р Т‘Р ВµРЎРѓР ВµРЎР‚Р С‘Р В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘ User
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Types, Max.Bot.Networking, FluentAssertions, xUnit
// СЂСџвЂ™РЋ Usage: Unit РЎвЂљР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ Р С—РЎР‚Р С•Р Р†Р ВµРЎР‚Р С”Р С‘ Р С”Р С•РЎР‚РЎР‚Р ВµР С”РЎвЂљР Р…Р С•РЎРѓРЎвЂљР С‘ РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ User

using FluentAssertions;
using Max.Bot.Networking;
using Max.Bot.Types;
using Xunit;

namespace Max.Bot.Tests.Unit.Types;

public class UserTests
{
    [Fact]
    public void Deserialize_ShouldDeserializeUser()
    {
        // Arrange
        var json = """{"id":123,"username":"testuser","firstName":"Test","lastName":"User","isBot":false}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<User>(json);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(123);
        result.Username.Should().Be("testuser");
        result.FirstName.Should().Be("Test");
        result.LastName.Should().Be("User");
        result.IsBot.Should().BeFalse();
    }

    [Fact]
    public void Deserialize_ShouldDeserializeUserWithNullFields()
    {
        // Arrange
        var json = """{"id":123,"isBot":true}""";

        // Act
        var result = MaxJsonSerializer.Deserialize<User>(json);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(123);
        result.Username.Should().BeNull();
        result.FirstName.Should().BeNull();
        result.LastName.Should().BeNull();
        result.IsBot.Should().BeTrue();
    }

    [Fact]
    public void Serialize_ShouldSerializeUser()
    {
        // Arrange
        var user = new User
        {
            Id = 123,
            Username = "testuser",
            FirstName = "Test",
            LastName = "User",
            IsBot = false
        };

        // Act
        var json = MaxJsonSerializer.Serialize(user);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("\"id\":123");
        json.Should().Contain("\"username\":\"testuser\"");
        json.Should().Contain("\"firstName\":\"Test\"");
        json.Should().Contain("\"lastName\":\"User\"");
        json.Should().Contain("\"isBot\":false");
    }

    [Fact]
    public void Serialize_ShouldNotIncludeNullFields()
    {
        // Arrange
        var user = new User
        {
            Id = 123,
            IsBot = true
        };

        // Act
        var json = MaxJsonSerializer.Serialize(user);

        // Assert
        json.Should().NotBeNullOrEmpty();
        json.Should().Contain("\"id\":123");
        json.Should().Contain("\"isBot\":true");
        json.Should().NotContain("\"username\"");
        json.Should().NotContain("\"firstName\"");
        json.Should().NotContain("\"lastName\"");
    }
}

