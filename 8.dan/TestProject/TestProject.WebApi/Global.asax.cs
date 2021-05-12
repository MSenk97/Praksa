﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using MyModels;
using StudentInterface;
using Students.Service;
using Students.Service.Common;
using TestProject.WebApi.Controllers;
using TestFakultetController;
using TestProject.WebApi.Repository;
using TestStudentController;
using TestProject.WebApi.Repository.Common;



namespace TestProject.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            #region DIModule

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<Student>().As<IStudent>();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<StudentController>().InstancePerRequest();
            builder.RegisterType<FakultetController>().InstancePerRequest();

            #endregion DIModule

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
