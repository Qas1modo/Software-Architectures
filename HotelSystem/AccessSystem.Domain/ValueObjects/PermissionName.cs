using AccessSystem.Domain.Core.Errors;
using SharedKernel.Domain.Core.Primitives;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Domain.ValueObjects;

public sealed class PermissionName : ValueObject
{
    public const int MaxLength = 256;
    
    private PermissionName(string value) => Value = value;
    
    public string Value { get; }
    
    public static implicit operator string(PermissionName permissionName) => permissionName.Value;
    
    public override string ToString() => Value;
    
    public static Result<PermissionName> Create(string permissionName) =>
        Result.Create(permissionName, DomainErrors.PermissionNameErrors.NullOrEmpty)
            .Ensure(pn => !string.IsNullOrWhiteSpace(pn), DomainErrors.PermissionNameErrors.NullOrEmpty)
            .Ensure(pn => pn.Length <= MaxLength, DomainErrors.PermissionNameErrors.LongerThanAllowed)
            .Map(pn => new PermissionName(pn));
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}