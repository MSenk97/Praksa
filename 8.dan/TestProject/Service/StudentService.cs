using System;
using System.Collections.Generic;
using StudentInterface;
using TestProject.WebApi.Repository.Common;
using TestProject.WebApi.Repository;
using Students.Service.Common;
using System.Threading.Tasks;


namespace Students.Service
{
    public class StudentService : IStudentService
    {
        public IStudentRepository Repository { get; set; }
        public StudentService()
        {
            Repository = new StudentRepository();
        }

       
        public async Task<List<IStudent>> GetAllStudents()
        {
            return await Repository.GetAllStudents();
        }

        public async Task<IStudent> GetStudent(int id)
        {
            return await Repository.GetStudent(id);
        }


        public async Task AddStudent(IStudent student)
        {
            await Repository.AddStudent(student);
        }

        public async Task UpdateStudent(int id, IStudent student)
        {
            await Repository.UpdateStudent(id, student);
        }

        public async Task DeleteStudent(int id)
        {
            await Repository.DeleteStudent(id);
        }


    }
}