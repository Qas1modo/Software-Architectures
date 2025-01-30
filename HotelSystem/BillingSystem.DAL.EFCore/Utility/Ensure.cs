using System.Numerics;

namespace BillingSystem.DAL.EFCore.Utility;

public static class Ensure
{
    public static void NotEmpty(string value, string message, string argumentName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(message, argumentName);
        }
    }

    public static void NotEmpty(Guid value, string message, string argumentName)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException(message, argumentName);
        }
    }

    public static void NotEmpty(DateTime value, string message, string argumentName)
    {
        if (value == default)
        {
            throw new ArgumentException(message, argumentName);
        }
    }

    public static void NotNull<T>(T value, string message, string argumentName)
        where T : class
    {
        if (value is null)
        {
            throw new ArgumentNullException(argumentName, message);
        }
    }

    public static void NotNegative<T>(T value, string message, string argumentName)
     where T : ISignedNumber<T>, IComparable<T>
    {
        if (value.CompareTo(default) < 0)
        {
            throw new ArgumentOutOfRangeException(argumentName, message);
        }
    }

    public static void NotNegativeOrZero<T>(T value, string message, string argumentName)
        where T : ISignedNumber<T>, IComparable<T>
    {
        if (value.CompareTo(default) <= 0)
        {
            throw new ArgumentOutOfRangeException(argumentName, message);
        }
    }
}
