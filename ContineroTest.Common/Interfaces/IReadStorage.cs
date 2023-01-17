namespace ContineroTest.Common.Interfaces;

using System.Threading.Tasks;
using ContineroTest.Common.Parameters;

public interface IReadStorage
{
    Task<string> ReadAsync(ParameterBase source);
}