namespace ContineroTest.Tests;

using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using ContineroTest.Common.Interfaces;
using ContineroTest.Common.Parameters;
using ContineroTest.Storages;
using Moq;
using Xunit;

public sealed class FileSystemReadStorageTests
{
    private readonly IReadStorage _storage;
    private readonly Mock<IFileSystem> _fileSystemMock;

    public FileSystemReadStorageTests()
    {
        _fileSystemMock = new Mock<IFileSystem>();
        _storage = new FileSystemReadStorage(_fileSystemMock.Object);
    }

    [Fact]
    public async Task ReadAsync_ValidPath_ReturnsString()
    {
        _fileSystemMock
            .Setup(x => x.File.Exists(It.IsAny<string>()))
            .Returns(true);

        _fileSystemMock
            .Setup(x => x.File.ReadAllTextAsync(It.IsAny<string>(), default))
            .ReturnsAsync("DummyText");

        var result = await _storage.ReadAsync(new ParameterBase
        {
            Path = "dummyFile"
        });

        Assert.Equal("DummyText", result);
    }

    [Fact]
    public async Task ReadAsync_InvalidPath_ThrowsException()
    {
        _fileSystemMock
            .Setup(x => x.File.Exists(It.IsAny<string>()))
            .Returns(false);

        await Assert.ThrowsAsync<FileNotFoundException>(() => _storage.ReadAsync(new ParameterBase
        {
            Path = "dummyFile"
        }));
    }
}