using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Infrastructure.GraphQL.Predicates
{
    public class WhereExpressionGraph : InputObjectGraphType<WhereExpression>
    {
        public WhereExpressionGraph()
        {
            Field(f => f.Field);
            Field(f => f.Value);
        }
    }
}
