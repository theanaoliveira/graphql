using System;
using System.Linq.Expressions;

namespace GraphQL.Application.UseCases.Expressions
{
    public class MakeExpression : IMakeExpression
    {
        private readonly IProperties properties;

        public MakeExpression(IProperties properties)
        {
            this.properties = properties;
        }

        public Expression<Func<T, bool>> GetExpression<T>(WhereExpression where) where T : class
        {
            var property = properties.GetProperty<T>(where.Field);

            if (property == null)
                throw new ArgumentNullException(where.Field, $"Property not found in {typeof(T)}");

            return func => func.GetPropertyValue(property.Name).ToString() == where.Value;
        }
    }
}