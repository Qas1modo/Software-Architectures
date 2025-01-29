using SharedKernel.Domain.Core.Primitives;

namespace SharedKernel.Application.Core.Exceptions.Exceptions;

/// <summary>
/// Represents an exception that occurs when a validation fails.
/// </summary>
public sealed class ValidationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="failures">The collection of validation failures.</param>
    public ValidationException(IEnumerable<Error> errors)
        : base("One or more validation failures has occurred.")
    {
        Errors = (IReadOnlyCollection<Error>)errors;
    }


    /// <summary>
    /// Gets the validation errors.
    /// </summary>
    public IReadOnlyCollection<Error> Errors { get; }
}
