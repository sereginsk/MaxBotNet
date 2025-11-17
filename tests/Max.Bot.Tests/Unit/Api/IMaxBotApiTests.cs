// СЂСџвЂњРѓ [IMaxBotApiTests] - Р СћР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ Р С–Р В»Р В°Р Р†Р Р…Р С•Р С–Р С• Р С‘Р Р…РЎвЂљР ВµРЎР‚РЎвЂћР ВµР в„–РЎРѓР В° API
// СЂСџР‹Р‡ Core function: Р СћР ВµРЎРѓРЎвЂљР С‘РЎР‚Р С•Р Р†Р В°Р Р…Р С‘Р Вµ РЎРѓРЎвЂљРЎР‚РЎС“Р С”РЎвЂљРЎС“РЎР‚РЎвЂ№ Р С‘Р Р…РЎвЂљР ВµРЎР‚РЎвЂћР ВµР в„–РЎРѓР В° IMaxBotApi
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Api, FluentAssertions, xUnit
// СЂСџвЂ™РЋ Usage: Unit РЎвЂљР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ Р С—РЎР‚Р С•Р Р†Р ВµРЎР‚Р С”Р С‘ Р С”Р С•РЎР‚РЎР‚Р ВµР С”РЎвЂљР Р…Р С•РЎРѓРЎвЂљР С‘ Р С‘Р Р…РЎвЂљР ВµРЎР‚РЎвЂћР ВµР в„–РЎРѓР В° IMaxBotApi

using FluentAssertions;
using Max.Bot.Api;
using Xunit;

namespace Max.Bot.Tests.Unit.Api;

public class IMaxBotApiTests
{
    [Fact]
    public void IMaxBotApi_ShouldHaveBotProperty()
    {
        // Assert
        typeof(IMaxBotApi).Should().HaveProperty<IBotApi>("Bot");
    }

    [Fact]
    public void IMaxBotApi_ShouldHaveMessagesProperty()
    {
        // Assert
        typeof(IMaxBotApi).Should().HaveProperty<IMessagesApi>("Messages");
    }

    [Fact]
    public void IMaxBotApi_ShouldHaveChatsProperty()
    {
        // Assert
        typeof(IMaxBotApi).Should().HaveProperty<IChatsApi>("Chats");
    }

    [Fact]
    public void IMaxBotApi_ShouldHaveUsersProperty()
    {
        // Assert
        typeof(IMaxBotApi).Should().HaveProperty<IUsersApi>("Users");
    }

    [Fact]
    public void IMaxBotApi_ShouldHaveFilesProperty()
    {
        // Assert
        typeof(IMaxBotApi).Should().HaveProperty<IFilesApi>("Files");
    }

    [Fact]
    public void IMaxBotApi_ShouldHaveSubscriptionsProperty()
    {
        // Assert
        typeof(IMaxBotApi).Should().HaveProperty<ISubscriptionsApi>("Subscriptions");
    }

    [Fact]
    public void IMaxBotApi_ShouldHaveAllRequiredProperties()
    {
        // Act
        var properties = typeof(IMaxBotApi).GetProperties();

        // Assert
        properties.Should().HaveCount(6);
        properties.Should().Contain(p => p.Name == "Bot" && p.PropertyType == typeof(IBotApi));
        properties.Should().Contain(p => p.Name == "Messages" && p.PropertyType == typeof(IMessagesApi));
        properties.Should().Contain(p => p.Name == "Chats" && p.PropertyType == typeof(IChatsApi));
        properties.Should().Contain(p => p.Name == "Users" && p.PropertyType == typeof(IUsersApi));
        properties.Should().Contain(p => p.Name == "Files" && p.PropertyType == typeof(IFilesApi));
        properties.Should().Contain(p => p.Name == "Subscriptions" && p.PropertyType == typeof(ISubscriptionsApi));
    }
}

