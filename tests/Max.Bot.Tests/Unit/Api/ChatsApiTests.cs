// 📁 [ChatsApiTests] - Тесты для ChatsApi
// 🎯 Core function: Тестирование методов ChatsApi (GetChatAsync, GetChatsAsync)
// 🔗 Key dependencies: Max.Bot.Api, Max.Bot.Configuration, Max.Bot.Networking, Max.Bot.Types, Moq, FluentAssertions, xUnit
// 💡 Usage: Unit тесты для проверки корректности работы ChatsApi

using FluentAssertions;
using Max.Bot.Api;
using Max.Bot.Configuration;
using Max.Bot.Networking;
using Max.Bot.Types;
using Max.Bot.Types.Enums;
using Moq;
using System.Net.Http;
using Xunit;

namespace Max.Bot.Tests.Unit.Api;

public class ChatsApiTests
{
    private readonly Mock<IMaxHttpClient> _mockHttpClient;
    private readonly MaxBotOptions _options;

    public ChatsApiTests()
    {
        _mockHttpClient = new Mock<IMaxHttpClient>();
        _options = new MaxBotOptions
        {
            Token = "test-token-123",
            BaseUrl = "https://api.max.ru/bot"
        };
    }

    [Fact]
    public async Task GetChatAsync_ShouldReturnChat_WhenRequestSucceeds()
    {
        // Arrange
        var chatId = 123456L;
        var expectedChat = new Chat
        {
            Id = chatId,
            Type = ChatType.Private,
            Username = "test_user"
        };

        var response = new Response<Chat>
        {
            Ok = true,
            Result = expectedChat
        };

        _mockHttpClient
            .Setup(x => x.SendAsync<Response<Chat>>(
                It.Is<MaxApiRequest>(req =>
                    req.Method == HttpMethod.Get &&
                    req.Endpoint == $"/test-token-123/chats/{chatId}"),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        var chatsApi = new ChatsApi(_mockHttpClient.Object, _options);

        // Act
        var result = await chatsApi.GetChatAsync(chatId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(expectedChat.Id);
        result.Type.Should().Be(expectedChat.Type);
        result.Username.Should().Be(expectedChat.Username);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task GetChatAsync_ShouldThrowArgumentException_WhenChatIdIsInvalid(long chatId)
    {
        // Arrange
        var chatsApi = new ChatsApi(_mockHttpClient.Object, _options);

        // Act
        var act = async () => await chatsApi.GetChatAsync(chatId);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithParameterName("chatId");
    }

    [Fact]
    public async Task GetChatsAsync_ShouldReturnChats_WhenRequestSucceeds()
    {
        // Arrange
        var expectedChats = new[]
        {
            new Chat { Id = 1, Type = ChatType.Private },
            new Chat { Id = 2, Type = ChatType.Group }
        };

        var response = new Response<Chat[]>
        {
            Ok = true,
            Result = expectedChats
        };

        _mockHttpClient
            .Setup(x => x.SendAsync<Response<Chat[]>>(
                It.Is<MaxApiRequest>(req =>
                    req.Method == HttpMethod.Get &&
                    req.Endpoint == "/test-token-123/chats"),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        var chatsApi = new ChatsApi(_mockHttpClient.Object, _options);

        // Act
        var result = await chatsApi.GetChatsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result[0].Id.Should().Be(1);
        result[1].Id.Should().Be(2);
    }
}

