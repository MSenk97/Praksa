using System;
using System.Collections.Generic;
using System.Linq;
using MyModels;
using TestProject.WebApi.Repository;
using System.Threading.Tasks;


namespace IFakultet.Service
{
    public class FakultetService
    {
        public FakultetRepository Repository { get; private set; }
        public FakultetService()
        {
            Repository = new FakultetRepository();
        }             
        
        public async Task<List<Fakultet>> GetAllFakultet()
        {
            return await Repository.GetAllFakultet();
        }

        public async Task<Fakultet> GetFakultet(int id)
        {
            return await Repository.GetFakultet(id);
        }


        public async Task AddFakultet(Fakultet fakultet)
        {
            await Repository.AddFakultet(fakultet);
        }

        public async Task UpdateFakultet(int id, Fakultet fakultet)
        {
            await Repository.UpdateFakultet(id, fakultet);
        }

        public async Task DeleteFakultet(int id)
        {
            await Repository.DeleteFakultet(id);
        }


    }
}