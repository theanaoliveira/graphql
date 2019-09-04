using System;
using System.Linq.Expressions;

namespace GraphQL.Application.UseCases.Expressions
{
    public class MakeExpression : IMakeExpression
    {
        public Expression<Func<T, bool>> GetExpression<T>(WhereExpression where) where T : class
        {
            var property = new Properties<T>().GetProperty(where.Field);
            return func => func.GetPropertyValue(property.Name).ToString() == where.Value;
        }
    }
}