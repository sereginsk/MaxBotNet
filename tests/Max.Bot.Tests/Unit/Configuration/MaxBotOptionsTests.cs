// СЂСџвЂњРѓ [MaxBotOptionsTests] - Р СћР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ Р В±Р В°Р В·Р С•Р Р†РЎвЂ№РЎвЂ¦ Р С•Р С—РЎвЂ Р С‘Р в„– Р В±Р С•РЎвЂљР В°
// СЂСџР‹Р‡ Core function: Р СћР ВµРЎРѓРЎвЂљР С‘РЎР‚Р С•Р Р†Р В°Р Р…Р С‘Р Вµ Р Р†Р В°Р В»Р С‘Р Т‘Р В°РЎвЂ Р С‘Р С‘ Р С‘ РЎРѓР С•Р В·Р Т‘Р В°Р Р…Р С‘РЎРЏ MaxBotOptions
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Configuration, FluentAssertions, xUnit
// СЂСџвЂ™РЋ Usage: Unit РЎвЂљР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ Р С—РЎР‚Р С•Р Р†Р ВµРЎР‚Р С”Р С‘ Р С”Р С•РЎР‚РЎР‚Р ВµР С”РЎвЂљР Р…Р С•РЎРѓРЎвЂљР С‘ РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ MaxBotOptions

using FluentAssertions;
using Max.Bot.Configuration;
using Xunit;

namespace Max.Bot.Tests.Unit.Configuration;

public class MaxBotOptionsTests
{
    [Fact]
    public void MaxBotOptions_ShouldHaveDefaultValues()
    {
        // Act
        var options = new MaxBotOptions();

        // Assert
        options.Token.Should().BeEmpty();
        options.BaseUrl.Should().Be("https://api.max.ru/bot");
    }

    [Fact]
    public void MaxBotOptions_ShouldValidate_WithValidValues()
    {
        // Arrange
        var options = new MaxBotOptions
        {
            Token = "test-token-123",
            BaseUrl = "https://api.max.ru/bot"
        };

        // Act
        var act = () => options.Validate();

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void MaxBotOptions_Validate_ShouldThrow_WhenTokenIsNullOrEmpty(string? token)
    {
        // Arrange
        var options = new MaxBotOptions
        {
            Token = token!,
            BaseUrl = "https://api.max.ru/bot"
        };

        // Act
        var act = () => options.Validate();

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithParameterName("Token")
            .WithMessage("*cannot be null or empty*");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void MaxBotOptions_Validate_ShouldThrow_WhenBaseUrlIsNullOrEmpty(string? baseUrl)
    {
        // Arrange
        var options = new MaxBotOptions
        {
            Token = "test-token-123",
            BaseUrl = baseUrl!
        };

        // Act
        var act = () => options.Validate();

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithParameterName("BaseUrl")
            .WithMessage("*cannot be null or empty*");
    }

    [Theory]
    [InlineData("not-a-uri")]
    [InlineData("relative/path")]
    public void MaxBotOptions_Validate_ShouldThrow_WhenBaseUrlIsInvalid(string baseUrl)
    {
        // Arrange
        var options = new MaxBotOptions
        {
            Token = "test-token-123",
            BaseUrl = baseUrl
        };

        // Act
        var act = () => options.Validate();

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithParameterName("BaseUrl");
    }

    [Theory]
    [InlineData("ftp://invalid.com")]
    [InlineData("file:///path/to/file")]
    public void MaxBotOptions_Validate_ShouldThrow_WhenBaseUrlUsesInvalidScheme(string baseUrl)
    {
        // Arrange
        var options = new MaxBotOptions
        {
            Token = "test-token-123",
            BaseUrl = baseUrl
        };

        // Act
        var act = () => options.Validate();

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithParameterName("BaseUrl")
            .WithMessage("*must use HTTP or HTTPS scheme*");
    }

    [Fact]
    public void MaxBotOptions_Validate_ShouldNotThrow_WithValidHttpUrl()
    {
        // Arrange
        var options = new MaxBotOptions
        {
            Token = "test-token-123",
            BaseUrl = "http://localhost:8080/bot"
        };

        // Act
        var act = () => options.Validate();

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void MaxBotOptions_Validate_ShouldNotThrow_WithValidHttpsUrl()
    {
        // Arrange
        var options = new MaxBotOptions
        {
            Token = "test-token-123",
            BaseUrl = "https://api.max.ru/bot"
        };

        // Act
        var act = () => options.Validate();

        // Assert
        act.Should().NotThrow();
    }
}

