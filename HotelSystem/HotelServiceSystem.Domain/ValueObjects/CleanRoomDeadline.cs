using HotelServiceSystem.Domain.Core.Primitives;

namespace HotelServiceSystem.Domain.ValueObjects;

public sealed class CleanRoomDeadline : ValueObject
{
    /// <summary>
    /// The first name maximum length.
    /// </summary>
    public const int DeadlineInHours = 7;

    /// <summary>
    /// Initializes a new instance of the <see cref="CleanRoomDeadline"/> class.
    /// </summary>
    /// <param name="value">The first name value.</param>
    private CleanRoomDeadline(DateTime value) => Value = value;

    /// <summary>
    /// Gets the first name value.
    /// </summary>
    public DateTime Value { get; }

    public static implicit operator DateTime(CleanRoomDeadline deadline) => deadline.Value;

    /// <summary>
    /// Creates a new <see cref="FirstName"/> instance based on the specified value.
    /// </summary>
    /// <param name="firstName">The first name value.</param>
    /// <returns>The result of the first name creation process containing the first name or an error.</returns>
    public static CleanRoomDeadline Create() => new (DateTime.Now.AddHours(DeadlineInHours));

    /// <inheritdoc />
    public override string ToString() => Value.ToString();

    /// <inheritdoc />
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
