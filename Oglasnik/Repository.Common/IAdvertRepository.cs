using System.Threading.Tasks;
using Models.Common;
using System.Web.Http;
using Oglasnik.Common;

namespace Repository.Common
{
    public interface IAdvertRepository
    {
        Task AddAdvert([FromBody] IAdvert advert);
        Task<IAdvert> AdvertById(int id);
        Task<System.Collections.Generic.List<IAdvert>> AllAdverts(ISortingAdverts howToSort, IFilteringAdverts howToFilter, IPaging advertPaging);
        Task DeleteAnAdvert(int id);
        Task UpdateAnAdvert(int id, [FromBody] IAdvert advert);
    }
}