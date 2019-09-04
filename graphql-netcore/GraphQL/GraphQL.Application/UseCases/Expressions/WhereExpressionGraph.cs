using GraphQL.Types;

namespace GraphQL.Application.UseCases.Expressions
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
