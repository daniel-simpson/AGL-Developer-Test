using FluentAssertions;
using NSubstitute;
using Xunit;
using CatLister.Services;
using System.Threading.Tasks;

namespace CatLister.Tests.Services
{
    public class PersonServiceFixture
    {
        ITestableHttpClient mockHttpClient;
        IPersonService mockPersonService;
        public PersonServiceFixture()
        {
            mockHttpClient = Substitute.For<ITestableHttpClient>();
            mockPersonService = Substitute.For<IPersonService>();
        }

        [Fact]
        public async Task Index_ReturnsEmptyLists_WhenUpstreamDataIsEmpty()
        {
            mockHttpClient.GetAsync().ReturnsForAnyArgs(_ =>
            {
                return Task.FromResult("[]");
            });

            var personService = new PersonService(mockHttpClient);
            var catsByGenderOwner = await personService.GetCatsByOwnerGenderAsync();

            catsByGenderOwner.Should().NotBeNull();
            catsByGenderOwner.CatsWithMaleOwners.Should().BeEmpty();
            catsByGenderOwner.CatsWithFemaleOwners.Should().BeEmpty();
        }
    }
}
