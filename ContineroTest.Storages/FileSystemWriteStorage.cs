namespace ContineroTest.Storages;

using System.IO.Abstractions;
using System.Threading.Tasks;
using ContineroTest.Common.Interfaces;
using ContineroTest.Common.Parameters;

public sealed class FileSystemWriteStorage : IWriteStorage
{
    private readonly IFileSystem _fileSystem;

    public FileSystemWriteStorage(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    /// <summary>
    /// Writes data to a filesystem
    /// </summary>
    /// <param name="target"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task WriteAsync(ParameterBase target, string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return;
        }

        await _fileSystem.File.WriteAllTextAsync(target.Path, input);
    }
}