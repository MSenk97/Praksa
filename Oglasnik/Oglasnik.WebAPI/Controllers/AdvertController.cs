using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service;
using Models;
using System.Threading.Tasks;
using Service.Common;
using Models.Common;
using AutoMapper;
using Oglasnik.Common;


namespace Oglasnik.WebAPI.Controllers
{
    public class AdvertRest
    {
        public int AdvertID { get; set; }


        public string Title { get; set; }

        public int Price { get; set; }

        public string Condition { get; set; }

        public string Description { get; set; }
        public string CategoryID { get; set; }

        public int DeliveryID { get; set; }

        public int UserID { get; set; }

    }
    public class SortingAdvertsRest
    {
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
    }
    public class FilteringAdvertsRest
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }

        public int PriceMin { get; set; }
        public int PriceMax { get; set; }

        public string Condition { get; set; }
    }
    public class PagingRest
    {
        public int Page { get; set; }
        public int DataPerPage { get; set; }
    }
    public class AdvertController : ApiController
    {
        public IAdvertService service { get; set; }
        //public IAuthorService authorService { get; set; }
        private readonly IMapper _mapper;
        public AdvertController(IAdvertService service, IMapper mapper)
        {
            this.service = service;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        public async Task<HttpResponseMessage> GetBooks([FromUri] SortingAdvertsRest howToSort, [FromUri] FilteringAdvertsRest howToFilter, [FromUri] PagingRest advertPaging)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<List<AdvertRest>>
                (await service.AllAdverts(_mapper.Map<SortingAdverts>(howToSort), _mapper.Map<FilteringAdverts>(howToFilter), _mapper.Map<Paging>(advertPaging))));
        }
        // GET api/values/5
        [HttpGet]
        public async Task<HttpResponseMessage> GetBookById(int id)
        {

            if (await service.AdvertById(id) != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<AdvertRest>(await service.AdvertById(id)));

                return response;
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR 404, Advert not found");
        }

        // POST api/values
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] AdvertRest advert)
        {
            if (await service.AdvertById(advert.AdvertID) == null)
            {
                 await service.AddAdvert(_mapper.Map<IAdvert>(advert));
                 return Request.CreateResponse(HttpStatusCode.OK, "New advert added");
                

            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "There is already an advert with that ID");

        }

        // PUT api/values/5
        public async Task<HttpResponseMessage> Put(int id, [FromBody] AdvertRest advert)
        {

            if (await service.AdvertById(id) != null)
            {
                await service.UpdateAnAdvert(id, _mapper.Map<IAdvert>(advert));
                return Request.CreateResponse(HttpStatusCode.OK, "Advert updated");


            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "There is no Advert with that ID");
        }
        public async Task<HttpResponseMessage> Delete(int id)
        {

            if (await service.AdvertById(id) != null)
            {
                await service.DeleteAnAdvert(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Advert deleted");

            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "ERROR 404, There is no advert with that ID");

        }

    }
}
