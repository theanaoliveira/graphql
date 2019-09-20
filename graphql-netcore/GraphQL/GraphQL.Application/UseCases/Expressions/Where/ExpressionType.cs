using GraphQL.Types;

namespace GraphQL.Application.UseCases.Expressions.Where
{
    public class ExpressionType : EnumerationGraphType<Expression>
    {
        public ExpressionType()
        {
            AddValue("EQUALS", "", 0);
            AddValue("CONTAINS", "", 1);
            AddValue("DIFF", "", 2);
        }
    }
}
