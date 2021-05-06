using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentModel;
using TestProject.WebApi.Repository;
using System.Data.SqlClient;
using System.Data;


namespace Students.Service
{
    public class StudentService
    {
        public static DataTable GetAllStudents()
        {
            return StudentRepository.GetAllStudents();
        }

        public static DataTable GetStudent(int id)
        {
            return StudentRepository.GetStudent(id);
        }

        public static void AddStudent(Student student)
        {
            StudentRepository.AddStudent(student);
            return; 
        }

        public static void UpdateStudent(int id, Student student)
        {
            StudentRepository.UpdateStudent(id, student);
            return;
        }

        public static void DeleteStudent(int id)
        {
            StudentRepository.DeleteStudent(id);
            return;
        }
 

    }
}