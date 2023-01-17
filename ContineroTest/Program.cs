namespace ContineroTest;

using System;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using ContineroTest.Common.Interfaces;
using ContineroTest.Common.Parameters;
using ContineroTest.Convertors;
using ContineroTest.Storages;
using Microsoft.Extensions.DependencyInjection;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        var serviceCollection = new ServiceCollection()
            .AddTransient<IWriteStorage, FileSystemWriteStorage>()
            .AddTransient<IFormatConverter, XmlToJsonConverter>()
            .AddTransient<IFileSystem, FileSystem>()
            .AddHttpClient();
        
        // Uncomment to try the filesystem reader
        /*
        var source = new ParameterBase         
        {
            Path = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml")
        };       
        serviceCollection.AddTransient<IReadStorage, FileSystemReadStorage>();
        */

        var source = new ParameterRest
        {
            Path = "https://gorest.co.in/public-api/users.xml",
            Url = "https://gorest.co.in/",
        };
        serviceCollection.AddTransient<IReadStorage, RestReadStorage>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
            
        var target = new ParameterBase
        {
            Path = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json")
        };

        var sourceStorage = serviceProvider.GetService<IReadStorage>();
        var targetStorage = serviceProvider.GetService<IWriteStorage>();
        var converter = serviceProvider.GetService<IFormatConverter>();

        var input = await sourceStorage.ReadAsync(source);
        var serializedDoc = converter.Convert(input);
        await targetStorage.WriteAsync(target, serializedDoc);
    }
}