using Newtonsoft.Json;

namespace CoreBase.Dto.RequestResponse.Request;

public class EncRequest
{
    [JsonProperty("Id")]
    public String? EncId { get; set; }
    [JsonIgnore]
    public Int64 Id { get; set; }
}
