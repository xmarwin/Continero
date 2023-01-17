namespace ContineroTest.Storages;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using ContineroTest.Common.Exceptions;
using ContineroTest.Common.Interfaces;
using ContineroTest.Common.Parameters;

public sealed class RestReadStorage : IReadStorage
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RestReadStorage(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// Reads data from a REST endpoint
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public async Task<string> ReadAsync(ParameterBase source)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient(((ParameterRest)source).Url);
            using var httpResponse = await httpClient.GetAsync(((ParameterRest)source).Path);
                
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new RestReadFailedException("Error code:" + httpResponse.StatusCode);
            }

            var content = await httpResponse.Content.ReadAsStringAsync();

            return content;
        }
        catch (Exception ex)
        {
            throw new RestReadFailedException("Failed to read data from a REST endpoint", ex);
        }
    }
}