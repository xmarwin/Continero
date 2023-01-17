namespace ContineroTest.Common.Interfaces;

public interface IFormatConverter
{
    /// <summary>
    /// Converts input from one format to another
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    string Convert(string input);
}