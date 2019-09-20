using GraphQL.Application.UseCases.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Tests.Builders.Expressions
{
    public class WhereExpressionBuilder
    {
        public string Field;
        public string Value;

        public static WhereExpressionBuilder New()
        {
            return new WhereExpressionBuilder()
            {
                Field = "name",
                Value = "Ana Caroline"
            };
        }

        public WhereExpressionBuilder WithField(string field)
        {
            Field = field;
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
                Value = Value
            };
    }
}
