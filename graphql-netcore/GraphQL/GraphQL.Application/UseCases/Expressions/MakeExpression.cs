using GraphQL.Application.UseCases.Expressions.Where;
using System;
using System.Linq.Expressions;

namespace GraphQL.Application.UseCases.Expressions
{
    public class MakeExpression : IMakeExpression
    {
        public readonly IProperties properties;

        public MakeExpression(IProperties properties)
        {
            this.properties = properties;
        }

        public Expression<Func<T, bool>> GetExpression<T>(WhereExpression where) where T : class
        {
            var property = properties.GetProperty<T>(where.Field);
            return func => func.GetPropertyValue(property.Name).ToString() == where.Value;
        }
    }
}