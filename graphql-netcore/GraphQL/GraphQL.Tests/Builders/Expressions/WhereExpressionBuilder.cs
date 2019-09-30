using GraphQL.Application.UseCases.Expressions.Where;

namespace GraphQL.Tests.Builders.Expressions
{
    public class WhereExpressionBuilder
    {
        public string Field;
        public Expression Expression;
        public string Value;

        public static WhereExpressionBuilder New()
        {
            return new WhereExpressionBuilder()
            {
                Field = "name",
                Expression = Expression.Equals,
                Value = "Ana Caroline"
            };
        }

        public WhereExpressionBuilder WithField(string field)
        {
            Field = field;
            return this;
        }

        public WhereExpressionBuilder WithExpression(Expression expression)
        {
            Expression = expression;
            return this;
        }

        public WhereExpressionBuilder WithValue(string value)
        {
            Value = value;
            return this;
        }

        public WhereExpression Build()
            => new WhereExpression()
            {
                Field = Field,
                Expression = Expression,
                Value = Value
            };
    }
}
