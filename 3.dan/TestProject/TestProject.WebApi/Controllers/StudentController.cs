using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;  
using System.Data.SqlClient;
using System.Web; 

namespace TestProject.WebAPI.Controllers
{
    public class Student
    {
        public int StudentID;
        public string Ime;
        public int FakultetID;
        public Student(int studentID, string Ime, int FakultetID)
        {
            this.StudentID = studentID;
            this.Ime = Ime;
            this.FakultetID = FakultetID;
        }

        public Student() { }
    }

    
    public class StudentController : ApiController
    {

        static readonly SqlConnection Connection = new SqlConnection(@"Server=tcp:msenk.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=msenk;Password=7991Schnekec1997;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        
        [HttpGet]
        [Route("api/student")]
        public HttpResponseMessage Get()
        {
            string queryString = "SELECT StudentID AS \"ID\", Ime AS \"Ime studenta\", FakultetID AS \"FakultetID\" FROM Student";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, Connection);
            DataTable Students = new DataTable();

            Connection.Open();
            adapter.Fill(Students);
            Connection.Close();

            return Request.CreateResponse(HttpStatusCode.OK, Students);
        }

        [HttpGet]
        [Route("api/student/{id}")]
        public HttpResponseMessage Get(int id)
        {
            string queryString = "SELECT StudentID AS \"ID\", Ime AS \"Ime studenta\" FROM Student WHERE StudentID =" + id+"";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, Connection);
            DataTable Students = new DataTable();

            Connection.Open();
            adapter.Fill(Students);
            Connection.Close();

            return Request.CreateResponse(HttpStatusCode.OK, Students);
        }

        [Route("api/student")]
        public HttpResponseMessage Post([FromBody] Student student)
        {
            
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:msenk.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=msenk;Password=7991Schnekec1997;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Student (StudentID, Ime, FakultetID) VALUES (@StudentID, @Ime, @FakultetID);";

            sqlCmd.Connection = myConnection;
            myConnection.Open();

            sqlCmd.Parameters.AddWithValue("@StudentID", student.StudentID);
            sqlCmd.Parameters.AddWithValue("@Ime", student.Ime);
            sqlCmd.Parameters.AddWithValue("@FakultetID", student.FakultetID);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [Route("api/student/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] Student student)
        {

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:msenk.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=msenk;Password=7991Schnekec1997;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE Student SET StudentID = @StudentID, Ime = @Ime, FakultetID = @FakultetID WHERE StudentID =" +id + ";";

            sqlCmd.Connection = myConnection;
            myConnection.Open();

            sqlCmd.Parameters.AddWithValue("@StudentID", student.StudentID);
            sqlCmd.Parameters.AddWithValue("@Ime", student.Ime);
            sqlCmd.Parameters.AddWithValue("@FakultetID", student.FakultetID);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [Route("api/student/{id}")]
        public IHttpActionResult Delete(int id)
        {
            SqlDataReader reader;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:msenk.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=msenk;Password=7991Schnekec1997;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "DELETE FROM Student WHERE StudentID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();

            return Ok();

        }
        //Dodati uvjete za CRUD metode s obzirom na id
    }

}