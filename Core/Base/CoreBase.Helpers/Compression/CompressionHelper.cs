using System.IO.Compression;
using System.Text;

namespace CoreBase.Helpers.Compression;

public static class CompressionHelper
{
    public static byte[]? CompressString(string text)
    {
        if (string.IsNullOrEmpty(text))
            return null;

        using MemoryStream memoryStream = new();
        using (GZipStream gzipStream = new(memoryStream, CompressionMode.Compress))
        using (StreamWriter writer = new(gzipStream, Encoding.UTF8))
        {
            writer.Write(text);
        }
        return memoryStream.ToArray();
    }

    public static string? DecompressString(byte[] compressedData)
    {
        if (compressedData == null || compressedData.Length == 0)
            return null;

        using MemoryStream memoryStream = new(compressedData);
        using GZipStream gzipStream = new(memoryStream, CompressionMode.Decompress);
        using StreamReader reader = new(gzipStream, Encoding.UTF8);
        return reader.ReadToEnd();
    }
}
