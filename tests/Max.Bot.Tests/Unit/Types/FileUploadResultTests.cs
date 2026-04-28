using System.Text.Json;
using FluentAssertions;
using Max.Bot.Types;
using Xunit;

namespace Max.Bot.Tests.Unit.Types;

public class FileUploadResultTests
{
    [Fact]
    public void FileUploadResult_ShouldDeserializeToken_FromVideoResponse()
    {
        // Arrange
        var json = "{\"token\":\"video-token-123\"}";

        // Act
        var result = JsonSerializer.Deserialize<FileUploadResult>(json);

        // Assert
        result.Should().NotBeNull();
        result!.Token.Should().Be("video-token-123");
    }

    [Fact]
    public void FileUploadResult_ShouldCaptureAdditionalProperties()
    {
        // Arrange
        var json = "{\"token\":\"abc\",\"unknown_field\":\"some value\"}";

        // Act
        var result = JsonSerializer.Deserialize<FileUploadResult>(json);

        // Assert
        result.Should().NotBeNull();
        result!.Token.Should().Be("abc");
        result.AdditionalProperties.Should().NotBeNull();
        result.AdditionalProperties.Should().ContainKey("unknown_field");
        result.AdditionalProperties!["unknown_field"].ToString().Should().Be("some value");
    }

    [Fact]
    public void FileUploadResult_ShouldSerializeCorrectly_WhenSendingToApi()
    {
        // Arrange
        var result = new FileUploadResult
        {
            Token = "test-token"
        };

        // Act
        var json = JsonSerializer.Serialize(result);

        // Assert
        json.Should().Be("{\"token\":\"test-token\"}");
    }
}
