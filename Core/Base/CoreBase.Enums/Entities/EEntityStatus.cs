using CoreBase.Attributes.Enums;
namespace CoreBase.Enums.Entities;

public enum EEntityStatus : ushort
{
    [EnumMetadata("Active", 10)]
    Active = 10,
    [EnumMetadata("In Active", 20)]
    Inactive = 20
}
