using GraphQL.Application.UseCases.Expressions;
using GraphQL.Domain.Perfil;
using GraphQL.Domain.Usuario;
using GraphQL.Tests.Builders.Expressions;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace GraphQL.Tests.Cases.Application.Expressions
{
    [UseAutofacTestFramework]
    public class MakeExpressionTest
    {
        private readonly IMakeExpression makeExpression;

        public MakeExpressionTest(IMakeExpression makeExpression)
        {
            this.makeExpression = makeExpression;
        }

        [Theory]
        [InlineData("id", "d003b5d3-b076-49e9-b51a-940acb2b7c70")]
        [InlineData("name", "Ana Caroline")]
        [InlineData("email", "anacaroline@graphql.com")]
        [InlineData("age", "26")]
        [InlineData("salario", "1000")]
        public void ShouldGetValidExpressionWithUserDomain(string field, string value)
        {
            var where = WhereExpressionBuilder.New().WithField(field).WithValue(value).Build();
            var expression = makeExpression.GetExpression<Usuario>(where);

            Assert.NotNull(expression);
        }

        [Theory]
        [InlineData("id", "d003b5d3-b076-49e9-b51a-940acb2b7c70")]
        [InlineData("name", "Comum")]
        public void ShouldGetValidExpressionWithProfileDomain(string field, string value)
        {
            var where = WhereExpressionBuilder.New().WithField(field).WithValue(value).Build();
            var expression = makeExpression.GetExpression<Perfil>(where);

            Assert.NotNull(expression);
        }
    }
}
