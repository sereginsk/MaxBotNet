// СЂСџвЂњРѓ [AttachmentRequestTests] - Р СћР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ AttachmentRequest
// СЂСџР‹Р‡ Core function: Р СџРЎР‚Р С•Р Р†Р ВµРЎР‚Р С”Р В° Р Р†Р В°Р В»Р С‘Р Т‘Р В°РЎвЂ Р С‘Р С‘ Р С‘ РЎРѓР ВµРЎР‚Р С‘Р В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘ AttachmentRequest
// СЂСџвЂќвЂ” Key dependencies: xUnit, FluentAssertions, Max.Bot.Types.Requests
// СЂСџвЂ™РЋ Usage: Unit РЎвЂљР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ РЎвЂљР С‘Р С—Р В° AttachmentRequest

using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using FluentAssertions;
using Max.Bot.Types.Requests;
using Xunit;

namespace Max.Bot.Tests.Unit.Types;

/// <summary>
/// Unit tests for <see cref="AttachmentRequest"/>.
/// </summary>
public class AttachmentRequestTests
{
    [Fact]
    public void Type_ShouldBeRequired()
    {
        // Arrange
        var request = new AttachmentRequest
        {
            Type = null!,
            Payload = new { token = "test" }
        };

        // Act
        var validationResults = ValidateModel(request);

        // Assert
        validationResults.Should().Contain(v => v.MemberNames.Contains("Type") && v.ErrorMessage != null && v.ErrorMessage.Contains("required", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void Payload_ShouldBeRequired()
    {
        // Arrange
        var request = new AttachmentRequest
        {
            Type = "image",
            Payload = null!
        };

        // Act
        var validationResults = ValidateModel(request);

        // Assert
        validationResults.Should().Contain(v => v.MemberNames.Contains("Payload") && v.ErrorMessage != null && v.ErrorMessage.Contains("required", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void ShouldSerializeCorrectly()
    {
        // Arrange
        var request = new AttachmentRequest
        {
            Type = "video",
            Payload = new { token = "test-token-123" }
        };

        // Act
        var json = JsonSerializer.Serialize(request);

        // Assert
        json.Should().Contain("\"type\":\"video\"");
        json.Should().Contain("\"payload\"");
    }

    [Theory]
    [InlineData("image")]
    [InlineData("video")]
    [InlineData("audio")]
    [InlineData("file")]
    public void Type_ShouldAcceptValidTypes(string type)
    {
        // Arrange
        var request = new AttachmentRequest
        {
            Type = type,
            Payload = new { token = "test" }
        };

        // Act
        var validationResults = ValidateModel(request);

        // Assert
        validationResults.Should().NotContain(v => v.MemberNames.Contains("Type"));
    }

    private static List<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(model);
        Validator.TryValidateObject(model, validationContext, validationResults, true);
        return validationResults;
    }
}

