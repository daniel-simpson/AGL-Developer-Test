using System.Threading.Tasks;

namespace CatLister.Services
{
    public interface ITestableHttpClient
    {
        Task<string> GetAsync();
    }
}
