using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using MyModels;
using StudentInterface;
using System.Configuration;
using System.Threading.Tasks;
using TestProject.WebApi.Repository.Common;
using AutoMapper;
using StudentsEntity;

namespace TestProject.WebApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private static readonly string myConnectionString = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
        private static readonly SqlConnection Connection = new SqlConnection(myConnectionString);
        private static SqlDataReader reader;
        private readonly IMapper mapper;

        public StudentRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }
        
        
        public async Task<List<IStudent>> GetAllStudents()
        {
            //Get metoda
            
            SqlCommand sqlCmd = new SqlCommand("SELECT StudentID AS \"ID\", Ime AS \"Ime studenta\", FakultetID AS \"FakultetID\" FROM Student", Connection);

            await Connection.OpenAsync();
            reader = sqlCmd.ExecuteReader();
            //IStudent student = null;
            List<IStudent> studentList = new List<IStudent>();
            while (reader.Read())
            {

                IStudent student = new Student();
                student.StudentID = Convert.ToInt32(reader.GetValue(0));
                student.Ime = reader.GetValue(1).ToString();
                student.FakultetID = Convert.ToInt32(reader.GetValue(2));
                studentList.Add(student);
            }

            Connection.Close();
            return mapper.Map<List<IStudent>>(studentList); 
        }

        public async Task<IStudent> GetStudent(int id)
        {
            //Get by ID metoda
            SqlCommand sqlCmd = new SqlCommand("SELECT StudentID AS \"ID\", Ime AS \"Ime studenta\", FakultetID AS \"ID\" FROM Student WHERE StudentID =" + id + "", Connection);

            await Connection.OpenAsync();
            reader = sqlCmd.ExecuteReader();
            IStudent student = null;
            while (reader.Read())
            {
                student = new Student();
                student.StudentID = Convert.ToInt32(reader.GetValue(0));
                student.Ime = reader.GetValue(1).ToString();
                student.FakultetID = Convert.ToInt32(reader.GetValue(2));
            }
            Connection.Close();
            return mapper.Map<IStudent>(student);
        }
        public async Task AddStudent(IStudent student)
        {
            //Post metoda
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO Student (StudentID, Ime, FakultetID) VALUES (@StudentID, @Ime, @FakultetID);", Connection);

            sqlCmd.Parameters.AddWithValue("@StudentID", student.StudentID);
            sqlCmd.Parameters.AddWithValue("@Ime", student.Ime);
            sqlCmd.Parameters.AddWithValue("@FakultetID", student.FakultetID);

            await Connection.OpenAsync();
            sqlCmd.ExecuteNonQuery();
            Connection.Close();
        }

        public async Task UpdateStudent(int id, IStudent student)
        {
            //Put metoda
            SqlCommand sqlCmd = new SqlCommand("UPDATE Student SET StudentID = @StudentID, Ime = @Ime, FakultetID = @FakultetID WHERE StudentID =" + id + ";", Connection);

            await Connection.OpenAsync();
            sqlCmd.Parameters.AddWithValue("@StudentID", student.StudentID);
            sqlCmd.Parameters.AddWithValue("@Ime", student.Ime);
            sqlCmd.Parameters.AddWithValue("@FakultetID", student.FakultetID);
            await sqlCmd.ExecuteNonQueryAsync();
            Connection.Close();

        }

        public async Task DeleteStudent(int id)
        {
            SqlCommand sqlCmd = new SqlCommand("DELETE FROM Student WHERE StudentID=" + id + "", Connection);

            await Connection.OpenAsync();
            SqlDataReader reader = await sqlCmd.ExecuteReaderAsync();
            Connection.Close();

        }
    }
}