using System;
using System.Collections.Generic;
using System.Linq;
using MyModels;
using Faks.Repository;
using Faks.Repository.Common;
using System.Threading.Tasks;
using FakultetInterface;
using Fakultet.Service.Common;

namespace Fakultet.Service
{
    public class FakultetService : IFakultetService
    {
        public IFakultetRepository Repository { get; set; }
        

        public async Task<List<IFakultet>> GetAllFakultet()
        {
            return await Repository.GetAllFakultet();
        }

        public async Task<IFakultet> GetFakultet(int id)
        {
            return await Repository.GetFakultet(id);
        }


        public async Task AddFakultet(IFakultet fakultet)
        {
            await Repository.AddFakultet(fakultet);
        }

        public async Task UpdateFakultet(int id, IFakultet fakultet)
        {
            await Repository.UpdateFakultet(id, fakultet);
        }

        public async Task DeleteFakultet(int id)
        {
            await Repository.DeleteFakultet(id);
        }
    }
}