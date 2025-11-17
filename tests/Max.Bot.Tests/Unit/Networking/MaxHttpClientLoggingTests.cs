// РЎР‚РЎСџРІР‚СљР С“ [MaxHttpClientLoggingTests] - Р В РЎС›Р В Р’ВµР РЋР С“Р РЋРІР‚С™Р РЋРІР‚в„– Р В РўвЂР В Р’В»Р РЋР РЏ Р В Р’В»Р В РЎвЂўР В РЎвЂ“Р В РЎвЂР РЋР вЂљР В РЎвЂўР В Р вЂ Р В Р’В°Р В Р вЂ¦Р В РЎвЂР РЋР РЏ HTTP Р В РЎвЂќР В Р’В»Р В РЎвЂР В Р’ВµР В Р вЂ¦Р РЋРІР‚С™Р В Р’В°
// РЎР‚РЎСџР вЂ№Р вЂЎ Core function: Р В РЎС›Р В Р’ВµР РЋР С“Р РЋРІР‚С™Р В РЎвЂР РЋР вЂљР В РЎвЂўР В Р вЂ Р В Р’В°Р В Р вЂ¦Р В РЎвЂР В Р’Вµ Р В Р’В»Р В РЎвЂўР В РЎвЂ“Р В РЎвЂР РЋР вЂљР В РЎвЂўР В Р вЂ Р В Р’В°Р В Р вЂ¦Р В РЎвЂР РЋР РЏ Р РЋР С“Р В РЎвЂўР В Р’В±Р РЋРІР‚в„–Р РЋРІР‚С™Р В РЎвЂР В РІвЂћвЂ“ Р В Р вЂ  MaxHttpClient
// РЎР‚РЎСџРІР‚СњРІР‚вЂќ Key dependencies: Max.Bot.Networking, Max.Bot.Configuration, Microsoft.Extensions.Logging, FluentAssertions, xUnit, Moq
// РЎР‚РЎСџРІР‚в„ўР Р‹ Usage: Unit Р РЋРІР‚С™Р В Р’ВµР РЋР С“Р РЋРІР‚С™Р РЋРІР‚в„– Р В РўвЂР В Р’В»Р РЋР РЏ Р В РЎвЂ”Р РЋР вЂљР В РЎвЂўР В Р вЂ Р В Р’ВµР РЋР вЂљР В РЎвЂќР В РЎвЂ Р В РЎвЂќР В РЎвЂўР РЋР вЂљР РЋР вЂљР В Р’ВµР В РЎвЂќР РЋРІР‚С™Р В Р вЂ¦Р В РЎвЂўР РЋР С“Р РЋРІР‚С™Р В РЎвЂ Р В Р’В»Р В РЎвЂўР В РЎвЂ“Р В РЎвЂР РЋР вЂљР В РЎвЂўР В Р вЂ Р В Р’В°Р В Р вЂ¦Р В РЎвЂР РЋР РЏ

using System.Net;
using System.Net.Http;
using System.Text;
using FluentAssertions;
using Max.Bot.Configuration;
using Max.Bot.Exceptions;
using Max.Bot.Networking;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Max.Bot.Tests.Unit.Networking;

public class MaxHttpClientLoggingTests
{
    private readonly MaxBotClientOptions _defaultOptions;

    public MaxHttpClientLoggingTests()
    {
        _defaultOptions = new MaxBotClientOptions
        {
            BaseUrl = "https://api.max.ru/bot",
            Timeout = TimeSpan.FromSeconds(30),
            RetryCount = 1
        };
    }

    [Fact]
    public async Task SendAsync_ShouldLogSuccessfulRequest()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<MaxHttpClient>>();
        var handler = new TestHttpMessageHandler
        {
            Response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"result\":\"success\"}", Encoding.UTF8, "application/json")
            }
        };
        var httpClient = new HttpClient(handler);
        var client = new MaxHttpClient(httpClient, _defaultOptions, loggerMock.Object);
        var request = new MaxApiRequest
        {
            Method = HttpMethod.Get,
            Endpoint = "test"
        };

        // Act
        await client.SendAsync<TestResponse>(request);

        // Assert
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Debug,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Sending") && v.ToString()!.Contains("test")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Debug,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("succeeded") && v.ToString()!.Contains("200")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_ShouldLogError_WhenRequestFails()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<MaxHttpClient>>();
        var handler = new TestHttpMessageHandler
        {
            Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Error", Encoding.UTF8, "text/plain")
            }
        };
        var httpClient = new HttpClient(handler);
        var client = new MaxHttpClient(httpClient, _defaultOptions, loggerMock.Object);
        var request = new MaxApiRequest
        {
            Method = HttpMethod.Get,
            Endpoint = "test"
        };

        // Act
        var act = async () => await client.SendAsync<TestResponse>(request);

        // Assert
        await act.Should().ThrowAsync<MaxNetworkException>();

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("failed")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_ShouldLogRetry_WhenRetrying()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<MaxHttpClient>>();
        var attemptCount = 0;
        var handler = new TestHttpMessageHandler
        {
            Response = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
            {
                Content = new StringContent("Service Unavailable", Encoding.UTF8, "text/plain")
            }
        };
        handler.OnRequest = (req) =>
        {
            attemptCount++;
            if (attemptCount < 2)
            {
                handler.Response = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    Content = new StringContent("Service Unavailable", Encoding.UTF8, "text/plain")
                };
            }
            else
            {
                handler.Response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{\"result\":\"success\"}", Encoding.UTF8, "application/json")
                };
            }
        };
        var httpClient = new HttpClient(handler);
        var client = new MaxHttpClient(httpClient, _defaultOptions, loggerMock.Object);
        var request = new MaxApiRequest
        {
            Method = HttpMethod.Get,
            Endpoint = "test"
        };

        // Act
        await client.SendAsync<TestResponse>(request);

        // Assert
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Retrying")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_ShouldLogDetailedLogging_WhenEnabled()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<MaxHttpClient>>();
        var options = new MaxBotClientOptions
        {
            BaseUrl = "https://api.max.ru/bot",
            Timeout = TimeSpan.FromSeconds(30),
            EnableDetailedLogging = true
        };
        var handler = new TestHttpMessageHandler
        {
            Response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"result\":\"success\"}", Encoding.UTF8, "application/json")
            }
        };
        var httpClient = new HttpClient(handler);
        var client = new MaxHttpClient(httpClient, options, loggerMock.Object);
        var request = new MaxApiRequest
        {
            Method = HttpMethod.Post,
            Endpoint = "test",
            Body = new { test = "value" }
        };

        // Act
        await client.SendAsync<TestResponse>(request);

        // Assert
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Trace,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Request body")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Trace,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Response body")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.AtLeastOnce);
    }

    [Fact]
    public async Task SendAsync_ShouldNotLogDetailedLogging_WhenDisabled()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<MaxHttpClient>>();
        var options = new MaxBotClientOptions
        {
            BaseUrl = "https://api.max.ru/bot",
            Timeout = TimeSpan.FromSeconds(30),
            EnableDetailedLogging = false
        };
        var handler = new TestHttpMessageHandler
        {
            Response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"result\":\"success\"}", Encoding.UTF8, "application/json")
            }
        };
        var httpClient = new HttpClient(handler);
        var client = new MaxHttpClient(httpClient, options, loggerMock.Object);
        var request = new MaxApiRequest
        {
            Method = HttpMethod.Post,
            Endpoint = "test",
            Body = new { test = "value" }
        };

        // Act
        await client.SendAsync<TestResponse>(request);

        // Assert
        loggerMock.Verify(
            x => x.Log(
                LogLevel.Trace,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Request body")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Never);

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Trace,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("Response body")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Never);
    }

    [Fact]
    public async Task SendAsync_ShouldLogAllRetriesExhausted_WhenAllFail()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<MaxHttpClient>>();
        var options = new MaxBotClientOptions
        {
            BaseUrl = "https://api.max.ru/bot",
            Timeout = TimeSpan.FromSeconds(30),
            RetryCount = 2
        };
        var handler = new TestHttpMessageHandler
        {
            Response = new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
            {
                Content = new StringContent("Service Unavailable", Encoding.UTF8, "text/plain")
            }
        };
        var httpClient = new HttpClient(handler);
        var client = new MaxHttpClient(httpClient, options, loggerMock.Object);
        var request = new MaxApiRequest
        {
            Method = HttpMethod.Get,
            Endpoint = "test"
        };

        // Act
        var act = async () => await client.SendAsync<TestResponse>(request);

        // Assert
        await act.Should().ThrowAsync<MaxNetworkException>();

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString()!.Contains("retry attempts failed")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    private class TestHttpMessageHandler : HttpMessageHandler
    {
        public HttpResponseMessage Response { get; set; } = new(HttpStatusCode.OK);
        public List<HttpRequestMessage> Requests { get; } = new();
        public Action<HttpRequestMessage>? OnRequest { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Requests.Add(request);
            OnRequest?.Invoke(request);

            // Read content from current Response (not cached) to support dynamic Response changes
            string? content = null;
            string? contentType = null;

            if (Response.Content != null)
            {
                try
                {
                    content = Response.Content.ReadAsStringAsync(cancellationToken).GetAwaiter().GetResult();
                    contentType = Response.Content.Headers.ContentType?.MediaType ?? "application/json";
                }
                catch (ObjectDisposedException)
                {
                    // If content is already disposed, try to create empty content
                    content = string.Empty;
                    contentType = "application/json";
                }
            }

            // Create a new HttpResponseMessage for each request to avoid ObjectDisposedException
            // when content is read multiple times (e.g., during retries)
            var response = new HttpResponseMessage(Response.StatusCode)
            {
                Content = content != null
                    ? new StringContent(content, Encoding.UTF8, contentType ?? "application/json")
                    : null
            };

            // Copy headers
            foreach (var header in Response.Headers)
            {
                response.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return Task.FromResult(response);
        }
    }

    private class TestResponse
    {
        public string? Result { get; set; }
    }
}

