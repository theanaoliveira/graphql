using FluentAssertions;
using GraphQL.Application.Repositories;
using GraphQL.Domain.Usuario;
using GraphQL.Tests.Builders.Usuario;
using GraphQL.Tests.TestCaseOrdering;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace GraphQL.Tests.Cases.Infrastructure
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("GraphQL.Tests.TestCaseOrdering.PriorityOrderer", "GraphQL.Tests")]
    public class UsuarioRepositoryTest
    {
        public readonly IUsersRepository usersRepository;
        public static Guid id = Guid.NewGuid();

        public UsuarioRepositoryTest(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        [Fact]
        [TestPriority(0)]
        public void ShouldAddNewUser()
        {
            var user = UsuarioBuilder.New().WithId(id).Build();
            var ret = usersRepository.Add(user);

            ret.Should().BeGreaterThan(0);
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldGetAllUsers()
        {
            var users = usersRepository.GetUsers();
            users.Should().NotBeNull();
            users.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldGetUserById()
        {
            //var users = usersRepository.GetUsers(id);

            //users.Should().NotBeNull();
            //users.As<Usuario>().Id.Should().Be(id);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteUser()
        {
            var ret = usersRepository.Delete(UsuarioBuilder.New().Build());
            ret.Should().BeGreaterThan(0);
        }
    }
}
