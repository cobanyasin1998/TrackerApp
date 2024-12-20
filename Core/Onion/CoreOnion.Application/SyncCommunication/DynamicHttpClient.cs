using CoreBase.Consts.General;
using CoreBase.Consts.SyncComm;
using CoreBase.Extensions.Json;
using CoreBase.Extensions.Identity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CoreOnion.Application.SyncCommunication;

public class DynamicHttpClient(IHttpContextAccessor httpContextAccessor)
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private static readonly HttpClient _httpClient = new(
        new HttpClientHandler()
        {
            MaxConnectionsPerServer = 100,
            AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
        })
    {
        Timeout = TimeSpan.FromSeconds(30)
    };

    public async Task<T?> SendRequestAsync<T>(DynamicHttpOptions options)
    {
        try
        {
            HttpRequestMessage requestMessage = new()
            {
                RequestUri = new Uri(options.Url),
                Method = options.Method
            };

            if (_httpContextAccessor.HttpContext?.GetToken(out var token) == true)
                requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            if (options.Data is not null && (options.Method == HttpMethod.Post || options.Method == HttpMethod.Put))
                requestMessage.Content = new StringContent(options.Data.ToJson(), System.Text.Encoding.UTF8, GeneralOperationConsts.ApplicationJsonKey);

            HttpResponseMessage response = await _httpClient.SendAsync(requestMessage, options.CancellationToken);
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync(options.CancellationToken);
            return JsonConvert.DeserializeObject<T?>(responseData);
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine($"{HttpClientConsts.RequestTimeout} {ex.Message}");
            throw;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"{HttpClientConsts.RequestFailed} {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{GeneralOperationConsts.OperationFailed} {ex.Message}");
            throw;
        }
    }
}
