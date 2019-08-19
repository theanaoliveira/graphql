using FluentAssertions;
using GraphQL.Tests.Builders.Perfil;
using System;
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

        [Fact]
        public void InvalidValuesShouldNotCreateWithId()
        {
            var model = PerfilBuilder.New().WithId(new Guid()).Build();

            model.IsValid.Should().BeFalse();
            model.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }
    }
}
