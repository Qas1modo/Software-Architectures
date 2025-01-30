namespace BillingSystem.DAL.EFCore.Primitives.Maybe;

public sealed class Maybe<T>
{
    private readonly T _value;

    private Maybe(T value) => _value = value;

    public bool HasValue => !HasNoValue;

    public bool HasNoValue => _value is null;

    public T Value => HasValue
        ? _value
        : throw new InvalidOperationException("The value can not be accessed because it does not exist.");

    public static Maybe<T> None => new(default);

    public static Maybe<T> From(T value) => new(value);

    public static implicit operator Maybe<T>(T value) => From(value);

    public static implicit operator T(Maybe<T> maybe) => maybe.Value;
}
