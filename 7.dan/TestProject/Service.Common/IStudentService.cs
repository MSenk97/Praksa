using StudentInterface;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.WebApi.Repository.Common;

namespace Students.Service.Common
{
    public interface IStudentService
    {
        IStudentRepository Repository { get; set; }

        Task AddStudent(IStudent student);
        Task DeleteStudent(int id);
        Task<List<IStudent>> GetAllStudents();
        Task<IStudent> GetStudent(int id);
        Task UpdateStudent(int id, IStudent student);
    }
}