using FluentAssertions;
using NSubstitute;
using Xunit;
using CatLister.Services;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Linq;

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

        [Fact]
        public async Task Index_ReturnsCorrectSplit_WhenUpstreamDataIsValid()
        {
            var testData = GetEmbeddedResourceContents("people.json");
            mockHttpClient.GetAsync().ReturnsForAnyArgs(_ =>
            {
                return Task.FromResult(testData);
            });

            var personService = new PersonService(mockHttpClient);
            var catsByGenderOwner = await personService.GetCatsByOwnerGenderAsync();

            catsByGenderOwner.Should().NotBeNull();
            catsByGenderOwner.CatsWithMaleOwners.Count().Should().Be(4);
            catsByGenderOwner.CatsWithMaleOwners.First().Name.Should().Be("Garfield");
            catsByGenderOwner.CatsWithMaleOwners.Last().Name.Should().Be("Tom");

            catsByGenderOwner.CatsWithFemaleOwners.Count().Should().Be(3);
            catsByGenderOwner.CatsWithFemaleOwners.First().Name.Should().Be("Garfield");
            catsByGenderOwner.CatsWithFemaleOwners.Last().Name.Should().Be("Tabby");
        }

        private string GetEmbeddedResourceContents(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"CatLister.Tests.{filename}";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
