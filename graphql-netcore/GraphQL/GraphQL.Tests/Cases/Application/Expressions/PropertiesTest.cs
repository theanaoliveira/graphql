using GraphQL.Application.UseCases.Expressions;
using GraphQL.Domain.Perfil;
using GraphQL.Domain.Usuario;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace GraphQL.Tests.Cases.Application.Expressions
{
    [UseAutofacTestFramework]
    public class PropertiesTest
    {
        private readonly IProperties properties;

        public PropertiesTest(IProperties properties)
        {
            this.properties = properties;
        }

        [Theory]
        [InlineData("id")]
        [InlineData("name")]
        [InlineData("age")]
        [InlineData("email")]
        [InlineData("salario")]
        public void ShoudlGetPropertyFromUserDomain(string field)
        {
            var property = properties.GetProperty<Usuario>(field);

            Assert.NotNull(property);
            Assert.Equal(field.ToUpper(), property.Name.ToUpper());
        }

        [Theory]
        [InlineData("id")]
        [InlineData("name")]
        public void ShoudlGetPropertyFromProfileDomain(string field)
        {
            var property = properties.GetProperty<Perfil>(field);

            Assert.NotNull(property);
            Assert.Equal(field.ToUpper(), property.Name.ToUpper());
        }
    }
}
