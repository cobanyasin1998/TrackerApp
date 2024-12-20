namespace CoreBase.Enums.Filtering;

public enum EFilterOperator : byte
{
    Equals = 1,
    NotEquals = 2,
    NotContains = 3,
    Contains = 4,
    GreaterThan = 5,
    LessThan = 6,
    GreaterThanOrEqual = 7,
    LessThanOrEqual = 8,
    NotEqual = 9,
    StartsWith = 10,
    EndsWith = 11,
    In = 12,
    NotIn = 13,
    Between = 14,
    NotBetween = 15,
    IsNull = 16,
    IsNotNull = 17,
    IsEmpty = 18,
    IsNotEmpty = 19,
    IsTrue = 20,
    IsFalse = 21,
    HasValue = 22,
    HasNoValue = 23
}
