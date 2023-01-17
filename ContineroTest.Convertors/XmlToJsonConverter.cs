namespace ContineroTest.Convertors;

using System;
using System.Xml;
using ContineroTest.Common.Exceptions;
using ContineroTest.Common.Interfaces;
using Newtonsoft.Json;

public sealed class XmlToJsonConverter : IFormatConverter
{
    /// <summary>
    /// Converts xml to json
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public string Convert(string input)
    {
        if (string.IsNullOrWhiteSpace(input?.Trim()))
        {
            throw new ArgumentNullException(nameof(input));
        }

        var doc = new XmlDocument();

        try
        {
            doc.LoadXml(input);

            return JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
        }
        catch (Exception ex)
        {
            throw new ConversionFailedException("Conversion failed", ex);
        }
    }
}