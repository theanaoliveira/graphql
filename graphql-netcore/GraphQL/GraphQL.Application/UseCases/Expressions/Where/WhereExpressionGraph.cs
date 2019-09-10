using GraphQL.Types;

namespace GraphQL.Application.UseCases.Expressions.Where
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
