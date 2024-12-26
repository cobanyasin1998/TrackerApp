using Newtonsoft.Json;

namespace CoreBase.Dto.Core.EncryptedDto;

public class EncryptedResponseDto
{
    [JsonIgnore]
    public Int64 Id { get; set; }
    [JsonProperty(nameof(Id))]
    public String EncId { get; set; } = String.Empty;
}
