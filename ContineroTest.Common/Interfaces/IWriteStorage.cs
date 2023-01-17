namespace ContineroTest.Common.Interfaces;

using System.Threading.Tasks;
using ContineroTest.Common.Parameters;

public interface IWriteStorage
{
    Task WriteAsync(ParameterBase target, string input);
}