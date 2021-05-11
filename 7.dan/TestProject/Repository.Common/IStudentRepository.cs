using StudentInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.WebApi.Repository.Common
{
    public interface IStudentRepository
    {
        Task AddStudent(IStudent student);
        Task DeleteStudent(int id);
        Task<List<IStudent>> GetAllStudents();
        Task<IStudent> GetStudent(int id);
        Task UpdateStudent(int id, IStudent student);
    }
}