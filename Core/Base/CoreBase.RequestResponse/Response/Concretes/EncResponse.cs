using Newtonsoft.Json;

namespace CoreBase.RequestResponse.Response.Concretes;

public class EncResponse
{
    [JsonIgnore]
    public long Id { get; set; }
    [JsonProperty(nameof(Id))]
    public String EncId { get; set; } = String.Empty;
}
