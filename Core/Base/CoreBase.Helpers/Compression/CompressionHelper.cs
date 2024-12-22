using System.IO.Compression;
using System.Text;

namespace CoreBase.Helpers.Compression;

public static class CompressionHelper
{
    public static byte[] CompressString(string text)
    {
        if (string.IsNullOrEmpty(text))
            return null;

        using var memoryStream = new MemoryStream();
        using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
        using (var writer = new StreamWriter(gzipStream, Encoding.UTF8))
        {
            writer.Write(text);
        }
        return memoryStream.ToArray();
    }

    public static string DecompressString(byte[] compressedData)
    {
        if (compressedData == null || compressedData.Length == 0)
            return null;

        using var memoryStream = new MemoryStream(compressedData);
        using var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
        using var reader = new StreamReader(gzipStream, Encoding.UTF8);
        return reader.ReadToEnd();
    }
}
