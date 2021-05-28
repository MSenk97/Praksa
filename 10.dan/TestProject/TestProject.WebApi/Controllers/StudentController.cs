using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using StudentInterface;
using System.Threading.Tasks;
using Students.Service.Common;
using AutoMapper;
using TestProject.Common;
using System.Web.Http.Cors;


namespace TestStudentController
{

    //[EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class StudentController : ApiController
    {

        private readonly IMapper mapper;

        #region Constructors

        private IStudentService Service { get; set; }
        public StudentController(IStudentService service, IMapper mapper)
        {
            this.Service = service;
            this.mapper = mapper;
        }

        public StudentController()
        {

        }
        #endregion Constructors

        

        #region methods

        [HttpGet]
        [Route("api/student")]
        public async Task<HttpResponseMessage> Get([FromUri]StudentFilterParams filterParams, [FromUri]StudentSortParams sortParams, [FromUri]StudentPageModel studentPage)
        {
            List<IStudent> studentList = await Service.GetAllStudents(filterParams, sortParams, studentPage);
            return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<List<StudentRest>>(studentList));
            /* List<IStudent> studentList = await Service.GetAllStudents(mapper.Map<IStudentFilterParams>(filterParams), mapper.Map<IStudentSortParams>(sortParams));
             return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<List<StudentRest>>(studentList));*/
        }

        [HttpGet]
        [Route("api/student/{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            IStudent student = await Service.GetStudent(id);
            if(student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "There is no record on the requested ID!");
            }
            return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<StudentRest>(student));
        }


        [HttpPost]
        [Route("api/student")]
        public async Task<HttpResponseMessage> Post([FromBody] StudentRest student)
        {
            IStudent studentonID = await Service.GetStudent(student.StudentID);
            if (studentonID != null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Cannot post to an unexisting record!"); 
            }
            await Service.AddStudent(mapper.Map<IStudent>(student));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/student/{id}")]
        public async Task<HttpResponseMessage> Put(int id, [FromBody] StudentRest student)
        {
            IStudent studentonID = await Service.GetStudent(student.StudentID);
            if (studentonID != null)
            {
                await Service.UpdateStudent(id, mapper.Map<IStudent>(student));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Cannot update an unexisting record!");
        }

        [HttpDelete]
        [Route("api/student/{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            IStudent studentonID = await Service.GetStudent(id);
            if (studentonID != null)
            {
                await Service.DeleteStudent(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Student with requested ID doesn't exist!");
        }

    }
    #endregion methods
    public class StudentRest
    {
        public int StudentID{ get; set;}
        public string Ime { get; set; }
        public int FakultetID { get; set; }

    }

    public class StudentFilterParamsRest
    {
        public string Ime { get; set; }
        public int FakultetID { get; set; }
    }

    public class StudentSortParamsRest
    {
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public bool ValidInput { get; set; }
    }
}