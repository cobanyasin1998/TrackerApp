namespace CoreBase.Extensions.File;

public static class FileGeneralExtensions
{
    public static Boolean IsValidFileExtension(String fileName, String[] allowedExtensions)
    {
        String fileExtension = Path.GetExtension(fileName).ToLower();
        return allowedExtensions.Contains(fileExtension);
    }

    public static String GenerateUniqueFileName(String originalFileName)
    {
        String extension = Path.GetExtension(originalFileName);
        return $"{System.Guid.NewGuid()}{extension}";
    }
}
