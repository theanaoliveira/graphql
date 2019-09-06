using FluentAssertions;
using GraphQL.Application.Repositories;
using GraphQL.Application.UseCases.Expressions;
using GraphQL.Domain.Perfil;
using GraphQL.Tests.Builders.Expressions;
using GraphQL.Tests.Builders.Perfil;
using GraphQL.Tests.TestCaseOrdering;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace GraphQL.Tests.Cases.Infrastructure
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("GraphQL.Tests.TestCaseOrdering.PriorityOrderer", "GraphQL.Tests")]
    public class PerfilRepositoryTest
    {
        public readonly IProfileRepository profileRepository;
        public readonly IMakeExpression makeExpression;
        public static Guid id = Guid.NewGuid();

        public PerfilRepositoryTest(IProfileRepository profileRepository, IMakeExpression makeExpression)
        {
            this.profileRepository = profileRepository;
            this.makeExpression = makeExpression;
        }

        [Fact]
        [TestPriority(0)]
        public void ShouldAddNewProfile()
        {
            var user = PerfilBuilder.New().WithId(id).Build();
            var ret = profileRepository.Add(user);

            ret.Should().BeGreaterThan(0);
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldGetAllProfiles()
        {
            var users = profileRepository.GetProfile();
            users.Should().NotBeNull();
            users.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldGetProfileById()
        {
            var where = WhereExpressionBuilder.New().WithField("id").WithValue(id.ToString()).Build();
            var perfil = profileRepository.GetProfile(makeExpression.GetExpression<Perfil>(where));

            perfil.Should().NotBeNull();
            perfil[0].Id.Should().Be(id);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteProfile()
        {
            var ret = profileRepository.Delete(PerfilBuilder.New().WithId(id).Build());
            ret.Should().BeGreaterThan(0);
        }
    }
}
