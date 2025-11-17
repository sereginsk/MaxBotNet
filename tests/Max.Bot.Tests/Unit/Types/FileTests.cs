// СЂСџвЂњРѓ [FileTests] - Р СћР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ Р СР С•Р Т‘Р ВµР В»Р С‘ File
// СЂСџР‹Р‡ Core function: Р СћР ВµРЎРѓРЎвЂљР С‘РЎР‚Р С•Р Р†Р В°Р Р…Р С‘Р Вµ РЎРѓР ВµРЎР‚Р С‘Р В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘/Р Т‘Р ВµРЎРѓР ВµРЎР‚Р С‘Р В°Р В»Р С‘Р В·Р В°РЎвЂ Р С‘Р С‘ File
// СЂСџвЂќвЂ” Key dependencies: Max.Bot.Types, Max.Bot.Networking, FluentAssertions, xUnit
// СЂСџвЂ™РЋ Usage: Unit РЎвЂљР ВµРЎРѓРЎвЂљРЎвЂ№ Р Т‘Р В»РЎРЏ Р С—РЎР‚Р С•Р Р†Р ВµРЎР‚Р С”Р С‘ Р С”Р С•РЎР‚РЎР‚Р ВµР С”РЎвЂљР Р…Р С•РЎРѓРЎвЂљР С‘ РЎР‚Р В°Р В±Р С•РЎвЂљРЎвЂ№ Р СР С•Р Т‘Р ВµР В»Р С‘ File

using FluentAssertions;
using Max.Bot.Networking;
using Xunit;
using MaxBotFile = Max.Bot.Types.File;

namespace Max.Bot.Tests.Unit.Types;

public class FileTests
{
    [Fact]
    public void File_ShouldDeserialize_FromJson()
    {
        // Arrange
        var json = """{"fileId":"file123","fileSize":1024,"filePath":"/path/to/file"}""";

        // Act
        var file = MaxJsonSerializer.Deserialize<MaxBotFile>(json);

        // Assert
        file.Should().NotBeNull();
        file.FileId.Should().Be("file123");
        file.FileSize.Should().Be(1024);
        file.FilePath.Should().Be("/path/to/file");
    }

    [Fact]
    public void File_ShouldDeserialize_WithNullableFields()
    {
        // Arrange
        var json = """{"fileId":"file123"}""";

        // Act
        var file = MaxJsonSerializer.Deserialize<MaxBotFile>(json);

        // Assert
        file.Should().NotBeNull();
        file.FileId.Should().Be("file123");
        file.FileSize.Should().BeNull();
        file.FilePath.Should().BeNull();
    }

    [Fact]
    public void File_ShouldSerialize_ToJson()
    {
        // Arrange
        var file = new MaxBotFile
        {
            FileId = "file123",
            FileSize = 1024,
            FilePath = "/path/to/file"
        };

        // Act
        var json = MaxJsonSerializer.Serialize(file);

        // Assert
        json.Should().Contain("\"fileId\":\"file123\"");
        json.Should().Contain("\"fileSize\":1024");
        json.Should().Contain("\"filePath\":\"/path/to/file\"");
    }
}

