using Newtonsoft.Json;

namespace CoreBase.Dto.Core.EncryptedDto;

public class EncryptedRequestDto
{
    [JsonProperty("Id")]
    public String? EncId { get; set; }
    [JsonIgnore]
    public Int64 Id { get; set; }
}
