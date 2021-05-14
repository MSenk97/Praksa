using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using StudentInterface;
using TestStudentController;
using StudentsEntity;
using TestProject.Common;

namespace TestProject.WebApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<StudentRest, IStudent>();
            CreateMap<IStudent, StudentRest>();
            CreateMap<StudentEntity, IStudent>();
            CreateMap<IStudent, StudentEntity>();
            CreateMap<IStudentFilterParams, StudentFilterParamsRest>();
            CreateMap<StudentFilterParamsRest, IStudentFilterParams>();
            CreateMap<IStudentSortParams, StudentSortParamsRest>();
            CreateMap<StudentSortParamsRest, IStudentSortParams>();
            //CreateMap<StudentFilterParams, IStudentFilterParams>();
            //CreateMap<IStudentFilterParams, StudentFilterParams>();

        }
    }
}