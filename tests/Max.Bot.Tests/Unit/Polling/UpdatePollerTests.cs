using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Max.Bot.Api;
using Max.Bot.Configuration;
using Max.Bot.Networking;
using Max.Bot.Polling;
using Max.Bot.Types;
using Moq;
using Xunit;

namespace Max.Bot.Tests.Unit.Polling;

public class UpdatePollerTests
{
    [Fact]
    public async Task StartAsync_ShouldUseRawTokenAuthorization_ForUpdatesRequest()
    {
        var options = new MaxBotOptions
        {
            Token = "test-token-123",
            BaseUrl = "https://api.max.ru/bot"
        };

        var pollClientMock = new Mock<IMaxHttpClient>();
        pollClientMock
            .Setup(x => x.SendAsyncRaw(
                It.Is<MaxApiRequest>(req =>
                    req.Method == HttpMethod.Get &&
                    req.Endpoint == "/updates" &&
                    req.Headers != null &&
                    req.Headers.ContainsKey("Authorization") &&
                    req.Headers["Authorization"] == "test-token-123"),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("{\"updates\":[],\"marker\":1}");

        var subscriptionsApiMock = new Mock<ISubscriptionsApi>();
        var botApiMock = new Mock<IMaxBotApi>();
        var handlerMock = new Mock<IUpdateHandler>();

        var poller = new UpdatePoller(
            botApiMock.Object,
            subscriptionsApiMock.Object,
            options,
            pollClientMock.Object);

        await poller.StartAsync(handlerMock.Object, CancellationToken.None);
        await Task.Delay(50);
        await poller.StopAsync(CancellationToken.None);

        pollClientMock.Verify(x => x.SendAsyncRaw(
            It.Is<MaxApiRequest>(req =>
                req.Method == HttpMethod.Get &&
                req.Endpoint == "/updates" &&
                req.Headers != null &&
                req.Headers.ContainsKey("Authorization") &&
                req.Headers["Authorization"] == "test-token-123"),
            It.IsAny<CancellationToken>()), Times.AtLeastOnce);
    }
}
