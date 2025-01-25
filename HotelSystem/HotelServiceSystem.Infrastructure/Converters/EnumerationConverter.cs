using HotelServiceSystem.Contracts.Enumerations;
using System.Linq.Expressions;

namespace HotelServiceSystem.Infrastructure.Converters;

public static class EnumerationConverter<TEntity>
{
    public static Expression<Func<TEntity, object>> OrderByConverterToExpression(OrderByEnum orderByEnum)
    {
        ParameterExpression parameter = Expression.Parameter(typeof(TEntity), nameof(TEntity));
        MemberExpression memberExpression = Expression.Property(parameter, orderByEnum.ToString());
        return (Expression<Func<TEntity, object>>) Expression.Lambda(memberExpression, parameter);
    }
}
