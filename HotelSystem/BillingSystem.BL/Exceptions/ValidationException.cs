using BillingSystem.DAL.EFCore.Primitives;

namespace BillingSystem.Application.Exceptions;

public sealed class ValidationException(IEnumerable<Error> errors) : Exception("One or more validation failures has occurred.")
{
    public IReadOnlyCollection<Error> Errors { get; } = (IReadOnlyCollection<Error>)errors;
}
