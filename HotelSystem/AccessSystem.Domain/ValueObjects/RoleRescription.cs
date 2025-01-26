using AccessSystem.Domain.Core.Errors;
using SharedKernel.Domain.Core.Primitives;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Domain.ValueObjects;

public sealed class RoleDescription : ValueObject
{
    public const int MaxLength = 5000;
    
    private RoleDescription(string value) => Value = value;
    
    public string Value { get; }

    public static implicit operator string(RoleDescription RoleDescription) => RoleDescription.Value;

    public override string ToString() => Value;
    
    public static Result<RoleDescription> Create(string RoleDescription) =>
        Result.Create(RoleDescription, DomainErrors.RoleDescriptionErrors.NullOrEmpty)
            .Ensure(pd => !string.IsNullOrWhiteSpace(pd), DomainErrors.RoleDescriptionErrors.NullOrEmpty)
            .Ensure(pd => pd.Length <= MaxLength, DomainErrors.RoleDescriptionErrors.LongerThanAllowed)
            .Map(pd => new RoleDescription(pd));
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}