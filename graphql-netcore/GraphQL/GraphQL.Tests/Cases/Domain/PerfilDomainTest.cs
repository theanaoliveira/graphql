using FluentAssertions;
using GraphQL.Tests.Builders.Perfil;
using Xunit;

namespace GraphQL.Tests.Cases.Domain
{
    public class PerfilDomainTest
    {
        [Fact]
        public void ShouldCreateUsuarioDomain()
        {
            var model = PerfilBuilder.New().Build();
            model.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithName(string valor)
        {
            var model = PerfilBuilder.New().WithName(valor).Build();

            model.IsValid.Should().BeFalse();
            model.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }

        [Theory]
        [InlineData(0)]
        public void InvalidValuesShouldNotCreateWithId(int valor)
        {
            var model = PerfilBuilder.New().WithId(valor).Build();

            model.IsValid.Should().BeFalse();
            model.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }
    }
}
