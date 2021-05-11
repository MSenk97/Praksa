using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using FakultetServices;
using MyModels;

namespace FakultetController
{

    public class FakultetController : ApiController
    {
        public FakultetService Service { get; private set; }
        public FakultetController()
        {
            Service = new FakultetService();
        }

        [HttpGet]
        [Route("api/fakultet")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.GetAllFakultet());
        }

        [HttpGet]
        [Route("api/fakultet/{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            List<Fakultet> listFakultet = await Service.GetAllFakultet();

            for (int i = 0; i < listFakultet.Count; i++)
            {
                if (listFakultet[i].FakultetID == id)
                {
                    await Service.GetFakultet(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, await Service.GetFakultet(id));
                    return response;
                }
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "There is no record on the requested ID!");
        }


        [HttpPost]
        [Route("api/fakultet")]
        public async Task<HttpResponseMessage> Post([FromBody] Fakultet fakultet)
        {
            List<Fakultet> listFakultet = await Service.GetAllFakultet();
            for (int i = 0; i < listFakultet.Count; i++)
            {
                if (listFakultet[i].FakultetID == fakultet.FakultetID)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "A record with the same ID already exists!");
                    return response;
                }
            }
            await Service.AddFakultet(fakultet);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/fakultet/{id}")]
        public async Task<HttpResponseMessage> Put(int id, [FromBody] Fakultet fakultet)
        {
            List<Fakultet> listFakultet = await Service.GetAllFakultet();

            for (int i = 0; i < listFakultet.Count; i++)
            {
                if (listFakultet[i].FakultetID == fakultet.FakultetID)
                {
                    await Service.UpdateFakultet(id, fakultet);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                    return response;
                }
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, "Cannot update an unexisting record!");
        }

        [HttpDelete]
        [Route("api/fakultet/{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            List<Fakultet> listFakultet = await Service.GetAllFakultet();

            for (int i = 0; i < listFakultet.Count; i++)
            {
                if (listFakultet[i].FakultetID == id)
                {
                    await Service.DeleteFakultet(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                    return response;
                }
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, "Deleting the requested record failed!");

        }

    }

}