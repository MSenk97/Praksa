using FakultetInterface;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Faks.Repository.Common
{
    public interface IFakultetRepository
    {   
        Task AddFakultet(IFakultet fakultet);
        Task DeleteFakultet(int id);
        Task<List<IFakultet>> GetAllFakultet();
        Task<IFakultet> GetFakultet(int id);
        Task UpdateFakultet(int id, IFakultet fakultet);
    }
}