namespace Identity.Application.Features.User.Constants;

public static class UserConstants
{
    private static readonly string Prefix = "User";

    public static readonly string Created = $"{Prefix} Created";
    public static readonly string Updated = $"{Prefix} Updated";
    public static readonly string Deleted = $"{Prefix} Deleted";
    public static readonly string NotFound = $"{Prefix} NotFound";


    public static readonly string EmailRequired = "Email address cannot be null or empty.";
    public static readonly string EmailInvalid = "Please enter a valid email address.";
    public static readonly string EmailTooLong = "Email address cannot exceed 255 characters.";
}
