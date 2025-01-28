using HotelServiceSystem.Domain.Core.Primitives;

namespace HotelServiceSystem.Application.Core.Exceptions;

/// <summary>
/// Represents an exception that occurs when a validation fails.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ValidationException"/> class.
/// </remarks>
/// <param name="failures">The collection of validation failures.</param>
public sealed class ValidationException(IEnumerable<Error> errors) : Exception("One or more validation failures has occurred.")
{

    /// <summary>
    /// Gets the validation errors.
    /// </summary>
    public IReadOnlyCollection<Error> Errors { get; } = (IReadOnlyCollection<Error>)errors;
}
