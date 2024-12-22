using System.Text.RegularExpressions;

namespace CoreBase.Extensions.Text;

public static class StringGeneralExtensions
{
    public static String AddSpacesBeforeUppercase(this String input)
       => Regex.Replace(input, "(?<!^)([A-Z])", " $1");
}
