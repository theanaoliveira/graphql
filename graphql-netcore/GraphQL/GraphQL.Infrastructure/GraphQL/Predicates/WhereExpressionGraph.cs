using GraphQL.Types;

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
