using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using StudentInterface;
using System.Threading.Tasks;
using Students.Service.Common;
using MyModels;

namespace TestStudentController
{

    public class StudentController : ApiController
    {
        #region Constructors
        public StudentController(IStudentService service)
        {
            this.Service = service;
        }

        #endregion Constructors

        private IStudentService Service { get; set; }

         
        #region methods

        [HttpGet]
        [Route("api/student")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.GetAllStudents());
        }

        [HttpGet]
        [Route("api/student/{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            if (id >= 0)
            {
                await Service.GetStudent(id);
                return Request.CreateResponse(HttpStatusCode.OK,await Service.GetStudent(id));
            }
           
            return Request.CreateResponse(HttpStatusCode.NotFound, "There is no record on the requested ID!");
        }
        
        
        [HttpPost]
        [Route("api/student")]
        public async Task<HttpResponseMessage> Post([FromBody] Student student)
        {
            if (await Service.GetStudent(student.StudentID) == null)
            {
                await Service.AddStudent(student);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Cannot post to an unexisting record!");
        }

        [HttpPut]
        [Route("api/student/{id}")]
        public async Task<HttpResponseMessage> Put(int id, [FromBody] Student student)
        {
            if (Service.GetStudent(id) != null)
            {
                await Service.UpdateStudent(id, student);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Cannot update an unexisting record!");
        }

        [HttpDelete]
        [Route("api/student/{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            if(await Service.GetStudent(id) != null)
            {
                await Service.DeleteStudent(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Student deleted!");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Student with requested ID doesn't exist!");
        }

    }
        #endregion methods

}