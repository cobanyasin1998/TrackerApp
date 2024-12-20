namespace CoreBase.Extensions.File;

public static class FileGeneralExtensions
{
    public static bool IsValidFileExtension(string fileName, string[] allowedExtensions)
    {
        var fileExtension = Path.GetExtension(fileName).ToLower();
        return allowedExtensions.Contains(fileExtension);
    }

    public static string GenerateUniqueFileName(string originalFileName)
    {
        var extension = Path.GetExtension(originalFileName);
        return $"{System.Guid.NewGuid()}{extension}";
    }
}
