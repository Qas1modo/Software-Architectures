using BillingSystem.DAL.EFCore.Primitives;

namespace BillingSystem.Presentation.Exceptions;

public class ApiErrorResponse(IReadOnlyCollection<Error> errors)
{
    public IReadOnlyCollection<Error> Errors { get; } = errors;
}
