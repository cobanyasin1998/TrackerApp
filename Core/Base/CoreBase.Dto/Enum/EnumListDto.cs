using CoreBase.Interfaces.DtoInterfaces;

namespace CoreBase.Dto.Enum;

public record EnumListDto(Int32 Id, String Name) : IDto;