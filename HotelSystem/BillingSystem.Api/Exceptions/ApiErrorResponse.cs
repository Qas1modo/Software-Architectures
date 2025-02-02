using SharedKernel.Domain.Core.Primitives;

namespace BillingSystem.Api.Exceptions;

public class ApiErrorResponse(IReadOnlyCollection<Error> errors)
{
    public IReadOnlyCollection<Error> Errors { get; } = errors;
}
