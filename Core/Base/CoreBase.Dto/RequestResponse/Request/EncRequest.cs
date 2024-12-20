using Newtonsoft.Json;

namespace CoreBase.Dto.RequestResponse.Request;

public class EncRequest
{
    [JsonProperty("Id")]
    public String? EncId { get; set; }
    [JsonIgnore]
    public long Id { get; set; }
}
