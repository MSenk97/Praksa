using System.Threading.Tasks;
using Models.Common;
using Oglasnik.Common;

namespace Service.Common
{
    public interface IAdvertService
    {
        Task AddAdvert(IAdvert value);
        Task<IAdvert> AdvertById(int id);
        Task<System.Collections.Generic.List<IAdvert>> AllAdverts(ISortingAdverts howToSort, IFilteringAdverts howToFilter, IPaging advertPaging);
        Task DeleteAnAdvert(int id);
        Task UpdateAnAdvert(int id, IAdvert value);
    }
}