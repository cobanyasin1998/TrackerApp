namespace CoreBase.Extensions.Size;

public static class SizeConversionExtensions
{
    public static Decimal ToKilobytes(this Decimal megabytes) 
        => megabytes * 1024;

    public static Decimal ToBytes(this Decimal megabytes)
        => megabytes * 1024 * 1024;

    public static Int32 ToBytes(this Int32 megabytes)
        => megabytes * 1024 * 1024;
}
