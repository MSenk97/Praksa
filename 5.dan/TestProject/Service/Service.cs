using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentModel;
using TestProject.WebApi.Repository;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;


namespace Students.Service
{
    public class StudentService
    {
        public StudentRepository Repository { get; private set; }
        public StudentService()
        {
            Repository = new StudentRepository();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await Repository.GetAllStudents();
        }

        public async Task<Student> GetStudent(int id)
        {
            return await Repository.GetStudent(id);
        }
        

        public async Task AddStudent(Student student)
        {
            await Repository.AddStudent(student);
        }

        public async Task UpdateStudent(int id, Student student)
        {
            await Repository.UpdateStudent(id, student);
        }

        public async Task DeleteStudent(int id)
        {
            await Repository.DeleteStudent(id);
        }


    }
}