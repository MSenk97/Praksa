using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Configuration;
using StudentModel;
using Students.Service;


namespace TestProject.WebAPI.Controllers
{
    
    public class StudentController : ApiController
    {
        
        [HttpGet]
        [Route("api/student")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, StudentService.GetAllStudents() );
        }

        [HttpGet]
        [Route("api/student/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, StudentService.GetStudent(id) );
        }
        
        [HttpPost]
        [Route("api/student")]
        public HttpResponseMessage Post([FromBody] Student student)
        {
            StudentService.AddStudent(student);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/student/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] Student student)
        {
            StudentService.UpdateStudent(id, student);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/student/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            StudentService.DeleteStudent(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
  
        //Dodati uvjete za CRUD metode s obzirom na id
    }

}