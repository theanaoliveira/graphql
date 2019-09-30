using FluentAssertions;
using GraphQL.Application.Repositories;
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
        public static Guid id = Guid.NewGuid();

        public PerfilRepositoryTest(IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        [Fact]
        [TestPriority(0)]
        public void ShouldAddNewProfile()
        {
            var profile = PerfilBuilder.New().WithId(id).Build();
            var ret = profileRepository.Add(profile);

            ret.Should().BeGreaterThan(0);
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldGetAllProfiles()
        {
            var profiles = profileRepository.GetProfile();
            profiles.Should().NotBeNull();
            profiles.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldGetProfileById()
        {
            var profiles = profileRepository.GetProfile(u=> u.Id == id);

            profiles.Should().NotBeNull();
            profiles[0].Id.Should().Be(id);
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
