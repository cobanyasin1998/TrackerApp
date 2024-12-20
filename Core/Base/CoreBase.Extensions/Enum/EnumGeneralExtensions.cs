using CoreBase.Dto.Enum;

namespace CoreBase.Extensions.Enum;

public static class EnumGeneralExtensions
{
    public static IEnumerable<string> GetNames<TEnum>() where TEnum : System.Enum 
        => System.Enum.GetNames(typeof(TEnum));

    public static IEnumerable<int> GetValues<TEnum>() where TEnum : System.Enum 
        => System.Enum.GetValues(typeof(TEnum)).Cast<int>();

    public static List<EnumListDto> ToEnumListDto<TEnum>() where TEnum : System.Enum =>
        System.Enum.GetValues(typeof(TEnum))
                   .Cast<TEnum>()
                   .Select(e => new EnumListDto(Id: Convert.ToInt32(e), Name: e.ToString()))
                   .ToList();
}
