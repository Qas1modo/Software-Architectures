using HotelServiceSystem.Domain.Core.Primitives;

namespace HotelServiceSystem.Domain.Core.Exceptions;

/// <summary>
/// Represents an exception that occurred in the domain.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DomainException"/> class.
/// </remarks>
/// <param name="error">The error containing the information about what happened.</param>
public class DomainException(Error error) : Exception(error.Message)
{

    /// <summary>
    /// Gets the error.
    /// </summary>
    public Error Error { get; } = error;
}
