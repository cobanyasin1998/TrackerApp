namespace CoreBase.Attributes.Enums;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class EnumMetadataAttribute(String description, Int32 code) : Attribute
{
    public String Description { get; } = description;
    public Int32 Code { get; } = code;
}
