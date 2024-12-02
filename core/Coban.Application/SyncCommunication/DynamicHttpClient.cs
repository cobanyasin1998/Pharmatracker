﻿using Newtonsoft.Json;

namespace Coban.Application.SyncCommunication;

public class DynamicHttpClient
{
    private static readonly HttpClient _httpClient;

    static DynamicHttpClient()
    {
        HttpClientHandler handler = new HttpClientHandler()
        {
            MaxConnectionsPerServer = 100,
            AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
        };

        _httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
    }

    public async Task<T> SendRequestAsync<T>(string url, HttpMethod method, object data = null, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = method
            };

            if (data is not null && (method == HttpMethod.Post || method == HttpMethod.Put))
            {
                string jsonContent = JsonConvert.SerializeObject(data);
                requestMessage.Content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await _httpClient.SendAsync(requestMessage, cancellationToken);
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseData);
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine($"Request Timeout: {ex.Message}");
            throw;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Request Error: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
            throw;
        }
    }
}

