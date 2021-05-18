using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Oglasnik.WebAPI.Controllers;
using DAL;
using Models.Common;
using Oglasnik.Common;

namespace Oglasnik.WebAPI.AutoMapper
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<AdvertRest, IAdvert>().ReverseMap();
            CreateMap<IAdvert, AdvertEntity>().ReverseMap();
            CreateMap<FilteringAdvertsRest, FilteringAdverts>().ReverseMap();
            CreateMap<SortingAdvertsRest, SortingAdverts>().ReverseMap();
            //CreateMap<HumanFilterModelRest, IHumanFilterModel>().ReverseMap();
            //CreateMap<HumanSortModelRest, IHumanSortModel>().ReverseMap();
            CreateMap<PagingRest, Paging>().ReverseMap();
            //CreateMap<IHumanModel, HumanEntity>().ReverseMap();
            //CreateMap<IHumanModel, PeopleRest>().ReverseMap();
        }
    }
}