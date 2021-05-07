using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using StudentModel;
using Students.Service;
using System.Threading.Tasks;


namespace TestProject.WebAPI.Controllers
{
    
    public class StudentController : ApiController
    {
        public StudentService Service { get; private set; }
        public StudentController()
        {
            Service = new StudentService();
        }

        [HttpGet]
        [Route("api/student")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.GetAllStudents() );
        }

        [HttpGet]
        [Route("api/student/{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            List<Student> listStudent = await Service.GetAllStudents();

            for (int i = 0; i < listStudent.Count; i++)
            {
                if (listStudent[i].StudentID == id)
                {
                    await Service.GetStudent(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK,await Service.GetStudent(id));
                    return response;
                }
            }
            
            return Request.CreateResponse(HttpStatusCode.NotFound, "There is no record on the requested ID!");
        }
        
        
        [HttpPost]
        [Route("api/student")]
        public async Task<HttpResponseMessage> Post([FromBody] Student student)
        {
            List<Student> listStudent = await Service.GetAllStudents();
            for (int i = 0; i < listStudent.Count; i++)
            {
                if (listStudent[i].StudentID == student.StudentID)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "A record with the same ID already exists!");
                    return response;
                }
            }
            await Service.AddStudent(student);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/student/{id}")]
        public async Task<HttpResponseMessage> Put(int id, [FromBody] Student student)
        {
            List<Student> listStudent = await Service.GetAllStudents();

            for (int i = 0; i < listStudent.Count; i++)
            {
                if (listStudent[i].StudentID == student.StudentID)
                {
                    await Service.UpdateStudent(id, student);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                    return response;
                }
            }
           
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Cannot update an unexisting record!");
        }

        [HttpDelete]
        [Route("api/student/{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            List<Student> listStudent = await Service.GetAllStudents();

            for (int i = 0; i < listStudent.Count; i++)
            {
                if (listStudent[i].StudentID == id)
                {
                    await Service.DeleteStudent(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                    return response;
                }
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, "Deleting the requested record failed!");
            
        }

    }

}