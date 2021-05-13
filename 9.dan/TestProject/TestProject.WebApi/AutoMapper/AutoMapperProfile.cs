using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using StudentInterface;
using TestStudentController;
using StudentsEntity;

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
        }
    }
}