namespace CoreOnion.Application.SyncCommunication;

public class DynamicHttpOptions(String url, HttpMethod method, Object? data = null, CancellationToken cancellationToken = default)
{
    public String Url { get; set; } = url;
    public HttpMethod Method { get; set; } = method;
    public Object? Data { get; set; } = data;
    public CancellationToken CancellationToken { get; set; } = cancellationToken;
}
