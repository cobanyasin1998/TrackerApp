using CoreBase.Attributes.Enums;
using System.Reflection;

namespace CoreBase.Extensions.Enum;

public static class EnumAttributeExtensions
{
    public static string GetMetaDataDescription(this System.Enum value)
    {
        FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());
        EnumMetadataAttribute[]? attributes = fieldInfo?.GetCustomAttributes(typeof(EnumMetadataAttribute), false) as EnumMetadataAttribute[];
        return attributes?.Length > 0 ? attributes[0].Description : value.ToString();
    }
    public static int GetCode(this System.Enum value)
    {
        FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());
        EnumMetadataAttribute[]? attributes = fieldInfo?.GetCustomAttributes(typeof(EnumMetadataAttribute), false) as EnumMetadataAttribute[];
        return attributes?.Length > 0 ? attributes[0].Code : 0;
    }
}
