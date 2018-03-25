using CatLister.ViewModels;
using System.Threading.Tasks;

namespace CatLister.Services
{
    public interface IPersonService
    {
        Task<HomeViewModel> GetCatsByOwnerGenderAsync();
    }
}
