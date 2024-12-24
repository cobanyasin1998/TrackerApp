using Newtonsoft.Json;

namespace CoreBase.Dto.RequestResponse.Response;

public class BaseResponse
{
    [JsonIgnore]
    public Int64 Id { get; set; }
    [JsonProperty(nameof(Id))]
    public String EncId { get; set; } = String.Empty;
}
