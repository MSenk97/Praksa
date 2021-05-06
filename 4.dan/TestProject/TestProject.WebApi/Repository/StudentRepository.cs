using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using StudentModel;
using System.Configuration;
using System.Web.Http;


namespace TestProject.WebApi.Repository
{
    public class StudentRepository
    {
        private static readonly string myConnectionString = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
        private static readonly SqlConnection Connection = new SqlConnection(myConnectionString);
        private static SqlDataReader reader;

        public static DataTable GetAllStudents()
        {
            //Get metoda
            string queryString = "SELECT StudentID AS \"ID\", Ime AS \"Ime studenta\", FakultetID AS \"FakultetID\" FROM Student";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, Connection);
            DataTable Students = new DataTable();

            Connection.Open();
            adapter.Fill(Students);
            Connection.Close();

            return Students;
        }

        public static DataTable GetStudent(int id)
        {
            //Get by ID metoda
            string queryString = "SELECT StudentID AS \"ID\", Ime AS \"Ime studenta\" FROM Student WHERE StudentID =" + id + "";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, Connection);
            DataTable Students = new DataTable();

            Connection.Open();
            adapter.Fill(Students);
            Connection.Close();

            return Students;
        }
        public static void AddStudent(Student student)
        {
            //Post metoda
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Student (StudentID, Ime, FakultetID) VALUES (@StudentID, @Ime, @FakultetID);";

            sqlCmd.Connection = Connection;
            Connection.Open();
           
            sqlCmd.Parameters.AddWithValue("@StudentID", student.StudentID);
            sqlCmd.Parameters.AddWithValue("@Ime", student.Ime);
            sqlCmd.Parameters.AddWithValue("@FakultetID", student.FakultetID);
            sqlCmd.ExecuteNonQuery();
            Connection.Close();

            return;
        }

        public static void UpdateStudent(int id, Student student)
        {
            //Put metoda
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE Student SET StudentID = @StudentID, Ime = @Ime, FakultetID = @FakultetID WHERE StudentID =" + id + ";";

            sqlCmd.Connection = Connection;
            Connection.Open();

            sqlCmd.Parameters.AddWithValue("@StudentID", student.StudentID);
            sqlCmd.Parameters.AddWithValue("@Ime", student.Ime);
            sqlCmd.Parameters.AddWithValue("@FakultetID", student.FakultetID);
            sqlCmd.ExecuteNonQuery();
            Connection.Close();

            return;
        }

        public static void DeleteStudent(int id) {

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "DELETE FROM Student WHERE StudentID=" + id + "";
            sqlCmd.Connection = Connection;
            Connection.Open();
            reader = sqlCmd.ExecuteReader();
            Connection.Close();
        }
    }
}