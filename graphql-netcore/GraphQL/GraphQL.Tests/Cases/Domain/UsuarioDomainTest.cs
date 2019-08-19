using FluentAssertions;
using GraphQL.Tests.Builders.Usuario;
using System;
using Xunit;

namespace GraphQL.Tests.Cases.Domain
{
    public class UsuarioDomainTest
    {
        [Fact]
        public void ShouldCreateUsuarioDomain()
        {
            var model = UsuarioBuilder.New().Build();
            model.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithName(string valor)
        {
            var model = UsuarioBuilder.New().WithName(valor).Build();

            model.IsValid.Should().BeFalse();
            model.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyShouldNotCreateWithEmail(string valor)
        {
            var model = UsuarioBuilder.New().WithEmail(valor).Build();

            model.IsValid.Should().BeFalse();
            model.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public void InvalidValuesShouldNotCreateWithId()
        {
            var model = UsuarioBuilder.New().WithId(new Guid()).Build();

            model.IsValid.Should().BeFalse();
            model.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }

        [Theory]
        [InlineData(0)]
        public void InvalidValuesShouldNotCreateWithAge(int valor)
        {
            var model = UsuarioBuilder.New().WithAge(valor).Build();

            model.IsValid.Should().BeFalse();
            model.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }

        [Theory]
        [InlineData(0)]
        public void InvalidValuesShouldNotCreateWithSalario(int valor)
        {
            var model = UsuarioBuilder.New().WithSalario(valor).Build();

            model.IsValid.Should().BeFalse();
            model.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }
    }
}
