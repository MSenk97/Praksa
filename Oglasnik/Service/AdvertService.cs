using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Common;
using Repository.Common;
using Models.Common;
using Oglasnik.Common;

namespace Service
{
    public class AdvertService : IAdvertService
    {
        protected IAdvertRepository Repository { get; set; }


        public AdvertService() { }
        public AdvertService(IAdvertRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<List<IAdvert>> AllAdverts(ISortingAdverts howToSort, IFilteringAdverts howToFilter, IPaging advertPaging)
        {
            return await Repository.AllAdverts(howToSort, howToFilter, advertPaging);
        }

        public async Task AddAdvert(IAdvert value)
        {

            await Repository.AddAdvert(value);
        }

        public async Task<IAdvert> AdvertById(int id)
        {
            return await Repository.AdvertById(id);
        }

        public async Task UpdateAnAdvert(int id, IAdvert value)
        {
            await Repository.UpdateAnAdvert(id, value);
        }

        public async Task DeleteAnAdvert(int id)
        {
            await Repository.DeleteAnAdvert(id);
        }
    }
}
