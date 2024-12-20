using CoreBase.Attributes.Enums;

namespace CoreBase.Enums.Exceptions;

public enum EErrorType : ushort
{
    [EnumMetadata("Bad Request", 10)]
    BadRequest = 400,
    [EnumMetadata("Not Found", 10)]
    NotFound = 404,
    [EnumMetadata("Un Authorized", 10)]
    Unauthorized = 401,
    [EnumMetadata("Forbidden", 10)]
    Forbidden = 403,
    [EnumMetadata("Conflict", 10)]
    Conflict = 409,
    [EnumMetadata("Un Processable Entity", 10)]
    UnprocessableEntity = 422,
    [EnumMetadata("Too Many Requests", 10)]
    TooManyRequests = 429,
}
