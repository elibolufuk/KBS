using System.Linq.Expressions;

namespace KBS.CreditAppSys.Application.Extensions;

public static class PredicateExtensions
{
    public static Expression<Func<T, bool>> And<T>(
        this Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(T));
        var leftVisitor = new ReplaceExpressionVisitor(left.Parameters[0], parameter);
        var leftExpr = leftVisitor.Visit(left.Body);

        var rightVisitor = new ReplaceExpressionVisitor(right.Parameters[0], parameter);
        var rightExpr = rightVisitor.Visit(right.Body);

        var andExpression = Expression.AndAlso(leftExpr, rightExpr);
        return Expression.Lambda<Func<T, bool>>(andExpression, parameter);
    }
}

class ReplaceExpressionVisitor(Expression oldValue, Expression newValue) : ExpressionVisitor
{
    private readonly Expression _oldValue = oldValue;
    private readonly Expression _newValue = newValue;

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    public override Expression Visit(Expression node)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    {
        return node == _oldValue ? _newValue : base.Visit(node);
    }
}