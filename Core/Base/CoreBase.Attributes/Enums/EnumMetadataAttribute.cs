namespace CoreBase.Attributes.Enums;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class EnumMetadataAttribute(string description, int code) : Attribute
{
    public string Description { get; } = description;
    public int Code { get; } = code;
}
