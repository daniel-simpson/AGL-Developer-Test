using System.Threading.Tasks;

namespace CatLister.Services
{
    public interface IWebClientService
    {
        Task<string> GetAsync(string path);
    }
}
