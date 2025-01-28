namespace HotelServiceSystem.Domain.Core.Primitives;

/// <summary>
/// Represents a concrete domain error.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Error"/> class.
/// </remarks>
/// <param name="code">The error code.</param>
/// <param name="message">The error message.</param>
public sealed class Error(string code, string message) : ValueObject
{

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public string Code { get; } = code;

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Message { get; } = message;

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;

    /// <inheritdoc />
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Code;
        yield return Message;
    }

    /// <summary>
    /// Gets the empty error instance.
    /// </summary>
    internal static Error None => new(string.Empty, string.Empty);
}
