using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace TestProject.WebApi.Controllers
{
    public class Student
    {
        
        public string name;
        public bool redovan;

        public Student(string name, bool redovan)
        {
            
            this.name = name;
            this.redovan = redovan;

        }
        public Student() { }
      
    }

    public class ValuesController : ApiController
    {
        public static List<Student> studentList = new List<Student>()
        {
            new Student {  name = "Marko Šenk", redovan = true },
            new Student {  name = "Luka Strapač", redovan = true },
            new Student {  name = "Filip Poljarević", redovan = false },
        };

        static List<string> languages = new List<string>()
        {
            "C#","Java","CSS"
        };
        // GET api/values
        
        public IEnumerable<Student> Get()
        {

            return studentList;
        }

        // GET api/values/1
        [HttpGet]
        public HttpResponseMessage GetName(int id)
        {
            if(studentList.Count < id || id < 0)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, "Error 404: object not found");
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, studentList[id].name);
                return response;
            }
        } 
       

        // POST api/values
        public HttpResponseMessage Post([FromBody] Student value)
        {
            studentList.Add(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody] Student value)
        {
            if (id < 0 || studentList.Count < id)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, "Error 404: invalid id");
                return response;
            }
            else 
            {
                studentList[id] = value;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, studentList[id]);
                return response;
            }
            
        }
       
        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            if (0 > id)
                return BadRequest("Not a valid student id");
            else 
                studentList.RemoveAt(id); 
            return Ok();
        }
    }
}
