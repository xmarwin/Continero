namespace ContineroTest.Convertors;

using System;
using System.Collections.Generic;
using System.Linq;
using ContineroTest.Common.Interfaces;

public sealed class TextToMorseCodeConverter : IFormatConverter
{
    /// <summary>
    /// Converts text to a Morse code
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public string Convert(string input)
    {
        if (string.IsNullOrWhiteSpace(input?.Trim()))
        {
            throw new ArgumentNullException(nameof(input));
        }

        var morseCode = GetMorseCode();

        input = input.Trim().ToLowerInvariant();
        var retval = string.Concat(input.Select(x => morseCode.TryGetValue(x, out var value) ? value + "/" : ""));

        return retval;
    }

    private static Dictionary<char, string> GetMorseCode()
    {
        var dict = new Dictionary<char, string>
        {
            {'a', ".-"},
            {'b', "-..."},
            {'c', "-.-."},
            {'d', "-.."},
            {'e', "."},
            {'f', "..-."},
            {'g', "--."},
            {'h', "...."},
            {'i', ".."},
            {'j', ".---"},
            {'k', "-.-"},
            {'l', ".-.."},
            {'m', "--"},
            {'n', "-."},
            {'o', "---"},
            {'p', ".--."},
            {'q', "--.-"},
            {'r', ".-."},
            {'s', "..."},
            {'t', "-"},
            {'u', "..-"},
            {'v', "...-"},
            {'w', ".--"},
            {'x', "-..-"},
            {'y', "-.--"},
            {'z', "--.."},
        };
        return dict;
    }
}