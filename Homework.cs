using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
namespace Continero.Homework
{
    public class Document
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml"); // this way of getting the file is correct, but smells


            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");
            try
            {
                FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
                var reader = new StreamReader(sourceStream); // use using statement
                string input = reader.ReadToEnd(); // use await reader.ReadToEndAsync()
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); // use throw only, otherwise losing stack. In this case - do not use at all because it does not bring any value.
            }
            var xdoc = XDocument.Parse(input);  // variable input should be declared outside of the try statement to be visible here
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };
            var serializedDoc = JsonConvert.SerializeObject(doc);
            var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(targetStream); // use using statement
            sw.Write(serializedDoc); // use await sw.WriteAsync(serializedDoc)
        }
    }
}