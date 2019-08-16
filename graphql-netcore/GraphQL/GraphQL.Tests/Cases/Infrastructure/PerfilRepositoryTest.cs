using FluentAssertions;
using GraphQL.Application.Repositories;
using GraphQL.Tests.Builders.Perfil;
using GraphQL.Tests.TestCaseOrdering;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace GraphQL.Tests.Cases.Infrastructure
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("GraphQL.Tests.TestCaseOrdering.PriorityOrderer", "GraphQL.Tests")]
    public class PerfilRepositoryTest
    {
        public readonly IProfileRepository profileRepository;

        public PerfilRepositoryTest(IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        [Fact]
        [TestPriority(0)]
        public void ShouldAddNewProfile()
        {
            var user = PerfilBuilder.New().Build();
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
            var users = profileRepository.GetProfile(1);

            users.Should().NotBeNull();
            users.Id.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteProfile()
        {
            var ret = profileRepository.Delete(PerfilBuilder.New().Build());
            ret.Should().BeGreaterThan(0);
        }
    }
}
