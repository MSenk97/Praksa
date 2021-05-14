using FakultetInterface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Faks.Repository.Common;

namespace Fakultet.Service.Common
{
    public interface IFakultetService
    {
        IFakultetRepository Repository { get; set; }

        Task AddFakultet(IFakultet fakultet);
        Task DeleteFakultet(int id);
        Task<List<IFakultet>> GetAllFakultet();
        Task<IFakultet> GetFakultet(int id);
        Task UpdateFakultet(int id, IFakultet fakultet);
    }
}