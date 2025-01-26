using AccessSystem.Domain.Core.Errors;
using SharedKernel.Domain.Core.Primitives;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Domain.ValueObjects;

public sealed class RoleName : ValueObject
{
    public const int MaxLength = 256;
    
    private RoleName(string value) => Value = value;
    
    public string Value { get; }
    
    public static implicit operator string(RoleName RoleName) => RoleName.Value;
    
    public override string ToString() => Value;
    
    public static Result<RoleName> Create(string RoleName) =>
        Result.Create(RoleName, DomainErrors.RoleNameErrors.NullOrEmpty)
            .Ensure(pn => !string.IsNullOrWhiteSpace(pn), DomainErrors.RoleNameErrors.NullOrEmpty)
            .Ensure(pn => pn.Length <= MaxLength, DomainErrors.RoleNameErrors.LongerThanAllowed)
            .Map(pn => new RoleName(pn));
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}