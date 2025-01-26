using AccessSystem.Domain.Core.Errors;
using SharedKernel.Domain.Core.Primitives;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Domain.ValueObjects;

public sealed class PermissionDescription : ValueObject
{
    public const int MaxLength = 5000;
    
    private PermissionDescription(string value) => Value = value;
    
    public string Value { get; }

    public static implicit operator string(PermissionDescription permissionDescription) => permissionDescription.Value;

    public static Result<PermissionDescription> Create(string permissionDescription) =>
        Result.Create(permissionDescription, DomainErrors.PermissionDescriptionErrors.NullOrEmpty)
            .Ensure(pd => !string.IsNullOrWhiteSpace(pd), DomainErrors.PermissionDescriptionErrors.NullOrEmpty)
            .Ensure(pd => pd.Length <= MaxLength, DomainErrors.PermissionDescriptionErrors.LongerThanAllowed)
            .Map(pd => new PermissionDescription(pd));
    public override string ToString() => Value;
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}