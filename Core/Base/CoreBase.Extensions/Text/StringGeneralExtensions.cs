using System.Text.RegularExpressions;

namespace CoreBase.Extensions.Text;

public static class StringGeneralExtensions
{
    public static String AddSpacesBeforeUppercase(this String input)
       => Regex.Replace(input, "(?<!^)([A-Z])", " $1");

    public static  String RemoveSpacesAndTrim(this String input)
        => Regex.Replace(input, @"\s+", " ").Trim();
}
