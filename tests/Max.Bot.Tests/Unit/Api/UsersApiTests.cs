// СЂСџвЂњРѓ [UsersApiTests] - Р СћР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ UsersApi
// СЂСџР‹Р‡ Core function: Р СћР ВµРЎРѓРЎвЂљР С‘РЎР‚Р С•Р Р†Р В°Р Р…Р С‘Р Вµ Р СР ВµРЎвЂљР С•Р Т‘Р С•Р Р† UsersApi (GetUserAsync)
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Api, Max.Bot.Configuration, Max.Bot.Networking, Max.Bot.Types, Moq, FluentAssertions, xUnit
// СЂСџвЂ™РЋ Usage: Unit РЎвЂљР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ Р С—РЎР‚Р С•Р Р†Р ВµРЎР‚Р С”Р С‘ Р С”Р С•РЎР‚РЎР‚Р ВµР С”РЎвЂљР Р…Р С•РЎРѓРЎвЂљР С‘ РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ UsersApi

using System.Net.Http;
using FluentAssertions;
using Max.Bot.Api;
using Max.Bot.Configuration;
using Max.Bot.Networking;
using Max.Bot.Types;
using Moq;
using Xunit;

namespace Max.Bot.Tests.Unit.Api;

public class UsersApiTests
{
    private readonly Mock<IMaxHttpClient> _mockHttpClient;
    private readonly MaxBotOptions _options;

    public UsersApiTests()
    {
        _mockHttpClient = new Mock<IMaxHttpClient>();
        _options = new MaxBotOptions
        {
            Token = "test-token-123",
            BaseUrl = "https://api.max.ru/bot"
        };
    }

    [Fact]
    public async Task GetUserAsync_ShouldReturnUser_WhenRequestSucceeds()
    {
        // Arrange
        var userId = 123456L;
        var expectedUser = new User
        {
            Id = userId,
            Username = "test_user",
            FirstName = "Test",
            LastName = "User",
            IsBot = false
        };

        var response = new Response<User>
        {
            Ok = true,
            Result = expectedUser
        };

        _mockHttpClient
            .Setup(x => x.SendAsync<Response<User>>(
                It.Is<MaxApiRequest>(req =>
                    req.Method == HttpMethod.Get &&
                    req.Endpoint == $"/test-token-123/users/{userId}"),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        var usersApi = new UsersApi(_mockHttpClient.Object, _options);

        // Act
        var result = await usersApi.GetUserAsync(userId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(expectedUser.Id);
        result.Username.Should().Be(expectedUser.Username);
        result.FirstName.Should().Be(expectedUser.FirstName);
        result.LastName.Should().Be(expectedUser.LastName);
        result.IsBot.Should().BeFalse();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task GetUserAsync_ShouldThrowArgumentException_WhenUserIdIsInvalid(long userId)
    {
        // Arrange
        var usersApi = new UsersApi(_mockHttpClient.Object, _options);

        // Act
        var act = async () => await usersApi.GetUserAsync(userId);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithParameterName("userId");
    }
}

