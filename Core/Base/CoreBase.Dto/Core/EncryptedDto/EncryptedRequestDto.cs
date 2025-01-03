using Newtonsoft.Json;

namespace CoreBase.Dto.Core.EncryptedDto;

public class EncryptedRequestDto
{
    [JsonIgnore]
    public Int64 Id { get; set; }
    [JsonProperty("Id")]
    public String? EncId { get; set; }

}
