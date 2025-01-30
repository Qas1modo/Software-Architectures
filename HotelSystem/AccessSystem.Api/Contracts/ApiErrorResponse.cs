using SharedKernel.Domain.Core.Primitives;

namespace AccessSystem.Api.Contracts
{
    /// <summary>
    /// Represents API an error response.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ApiErrorResponse"/> class.
    /// </remarks>
    /// <param name="errors">The enumerable collection of errors.</param>
    public class ApiErrorResponse(IReadOnlyCollection<Error> errors)
    {

        /// <summary>
        /// Gets the errors.
        /// </summary>
        public IReadOnlyCollection<Error> Errors { get; } = errors;
    }
}
