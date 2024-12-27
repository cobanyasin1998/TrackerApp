using System;
using System.Text;

namespace CoreBase.Extensions.Random;

public class GeneralRandomHelper
{
    private static readonly System.Random _random = new();

    private const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-+=<>?";
    private const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
    private const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string numberChars = "1234567890";
    private const string specialChars = "!@#$%^&*()_-+=<>?";

    public static string GenerateRandom(int length)
    {
        StringBuilder password = new(length);

        for (int i = 0; i < length; i++)
        {
            int index = _random.Next(validChars.Length);
            password.Append(validChars[index]);
        }

        return password.ToString();
    }
    public static string GenerateRandomPassword(int length = 12) 
        => GenerateRandom(length, true, true, true, true);
   
    public static string GenerateRandom(int length, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecialChars)
    {
        StringBuilder validChars = new();

        if (includeLowercase)
            validChars.Append(lowerChars);
        if (includeUppercase)
            validChars.Append(upperChars);
        if (includeNumbers)
            validChars.Append(numberChars);
        if (includeSpecialChars)
            validChars.Append(specialChars);

        if (validChars.Length == 0)
            throw new ArgumentException("En az bir karakter türü seçilmelidir.");

        StringBuilder password = new(length);

        for (int i = 0; i < length; i++)
        {
            int index = _random.Next(validChars.Length);
            password.Append(validChars[index]);
        }

        return password.ToString();
    }
}