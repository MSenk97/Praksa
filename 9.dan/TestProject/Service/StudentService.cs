using System;
using System.Collections.Generic;
using StudentInterface;
using TestProject.WebApi.Repository.Common;
using TestProject.WebApi.Repository;
using Students.Service.Common;
using System.Threading.Tasks;
using TestProject.Common;


namespace Students.Service
{
    public class StudentService : IStudentService
    {
        public IStudentRepository Repository { get; set; }
        public StudentService(IStudentRepository repository)
        {
            this.Repository = repository;
        }


        public async Task<List<IStudent>> GetAllStudents(StudentFilterParams filterParams, StudentSortParams sortParams)
        {
            return await Repository.GetAllStudents(filterParams, sortParams);
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