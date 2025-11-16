// 📁 [MessagesApiTests] - Тесты для MessagesApi
// 🎯 Core function: Тестирование методов MessagesApi (SendMessageAsync, GetMessagesAsync)
// 🔗 Key dependencies: Max.Bot.Api, Max.Bot.Configuration, Max.Bot.Networking, Max.Bot.Types, Moq, FluentAssertions, xUnit
// 💡 Usage: Unit тесты для проверки корректности работы MessagesApi

using FluentAssertions;
using Max.Bot.Api;
using Max.Bot.Configuration;
using Max.Bot.Exceptions;
using Max.Bot.Networking;
using Max.Bot.Types;
using Moq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Max.Bot.Tests.Unit.Api;

public class MessagesApiTests
{
    private readonly Mock<IMaxHttpClient> _mockHttpClient;
    private readonly MaxBotOptions _options;

    public MessagesApiTests()
    {
        _mockHttpClient = new Mock<IMaxHttpClient>();
        _options = new MaxBotOptions
        {
            Token = "test-token-123",
            BaseUrl = "https://api.max.ru/bot"
        };
    }

    [Fact]
    public async Task SendMessageAsync_ShouldReturnMessage_WhenRequestSucceeds()
    {
        // Arrange
        var chatId = 123456L;
        var text = "Hello, World!";
        var expectedMessage = new Message
        {
            Id = 789,
            Text = text,
            Chat = new Chat { Id = chatId }
        };

        var response = new Response<Message>
        {
            Ok = true,
            Result = expectedMessage
        };

        _mockHttpClient
            .Setup(x => x.SendAsync<Response<Message>>(
                It.Is<MaxApiRequest>(req =>
                    req.Method == HttpMethod.Post &&
                    req.Endpoint == "/test-token-123/messages" &&
                    req.Body != null),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        var messagesApi = new MessagesApi(_mockHttpClient.Object, _options);

        // Act
        var result = await messagesApi.SendMessageAsync(chatId, text);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(expectedMessage.Id);
        result.Text.Should().Be(expectedMessage.Text);
        result.Chat.Should().NotBeNull();
        result.Chat!.Id.Should().Be(chatId);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task SendMessageAsync_ShouldThrowArgumentException_WhenChatIdIsInvalid(long chatId)
    {
        // Arrange
        var messagesApi = new MessagesApi(_mockHttpClient.Object, _options);

        // Act
        var act = async () => await messagesApi.SendMessageAsync(chatId, "test");

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithParameterName("chatId");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task SendMessageAsync_ShouldThrowArgumentException_WhenTextIsNullOrEmpty(string? text)
    {
        // Arrange
        var messagesApi = new MessagesApi(_mockHttpClient.Object, _options);

        // Act
        var act = async () => await messagesApi.SendMessageAsync(123456L, text!);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithParameterName("text");
    }

    [Fact]
    public async Task GetMessagesAsync_ShouldReturnMessages_WhenRequestSucceeds()
    {
        // Arrange
        var chatId = 123456L;
        var expectedMessages = new[]
        {
            new Message { Id = 1, Text = "Message 1", Chat = new Chat { Id = chatId } },
            new Message { Id = 2, Text = "Message 2", Chat = new Chat { Id = chatId } }
        };

        var response = new Response<Message[]>
        {
            Ok = true,
            Result = expectedMessages
        };

        _mockHttpClient
            .Setup(x => x.SendAsync<Response<Message[]>>(
                It.Is<MaxApiRequest>(req =>
                    req.Method == HttpMethod.Get &&
                    req.Endpoint == "/test-token-123/messages" &&
                    req.QueryParameters != null &&
                    req.QueryParameters.ContainsKey("chatId") &&
                    req.QueryParameters["chatId"] == chatId.ToString()),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(response);

        var messagesApi = new MessagesApi(_mockHttpClient.Object, _options);

        // Act
        var result = await messagesApi.GetMessagesAsync(chatId);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result[0].Id.Should().Be(1);
        result[1].Id.Should().Be(2);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task GetMessagesAsync_ShouldThrowArgumentException_WhenChatIdIsInvalid(long chatId)
    {
        // Arrange
        var messagesApi = new MessagesApi(_mockHttpClient.Object, _options);

        // Act
        var act = async () => await messagesApi.GetMessagesAsync(chatId);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithParameterName("chatId");
    }
}

