namespace CoreOnion.Application.SyncCommunication;

public class DynamicHttpOptions(string url, HttpMethod method, object? data = null, CancellationToken cancellationToken = default)
{
    public string Url { get; set; } = url;
    public HttpMethod Method { get; set; } = method;
    public object? Data { get; set; } = data;
    public CancellationToken CancellationToken { get; set; } = cancellationToken;
}
