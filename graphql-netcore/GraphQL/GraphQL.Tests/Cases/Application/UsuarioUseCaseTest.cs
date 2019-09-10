using FluentAssertions;
using GraphQL.Application.Repositories;
using GraphQL.Application.UseCases.Usuario;
using GraphQL.Tests.Builders.Usuario;
using GraphQL.Tests.TestCaseOrdering;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace GraphQL.Tests.Cases.Application
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("GraphQL.Tests.TestCaseOrdering.PriorityOrderer", "GraphQL.Tests")]
    public class UsuarioUseCaseTest
    {
        private readonly IUsuarioUseCase usuarioUseCase;
        public readonly IUsersRepository usersRepository;

        public UsuarioUseCaseTest(IUsuarioUseCase usuarioUseCase, IUsersRepository usersRepository)
        {
            this.usuarioUseCase = usuarioUseCase;
            this.usersRepository = usersRepository;
        }

        [Fact]
        [TestPriority(0)]
        public void ShouldAddNewUser()
        {
            var user = UsuarioBuilder.New().WithId(Guid.NewGuid()).Build();
            var ret = usersRepository.Add(user);

            ret.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("{ users { id name email } }")]
        [TestPriority(1)]
        public void ShouldExecuteUseCase(string query)
        {
            var ret = usuarioUseCase.Execute(query);

            ret.Should().NotBeNull();
            ret.Result.Errors?.Count.Should().Be(0);
        }
    }
}
