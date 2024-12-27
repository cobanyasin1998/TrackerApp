using Newtonsoft.Json;

namespace CoreBase.Dto.Core.EncryptedDto;

public class EncryptedResponseDto
{
    [JsonIgnore]
    public Int64 Id { get; set; }
    [JsonProperty(nameof(Id))]
    public String EncId { get; set; } = default!;


    public bool ShouldSerializeId() => IncludeIdInJson;

    [JsonIgnore]
    public bool IncludeIdInJson { get; set; } = false;
}