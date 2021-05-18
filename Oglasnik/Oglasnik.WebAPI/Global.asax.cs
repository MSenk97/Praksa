using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Oglasnik.WebAPI.Controllers;
using Models;
using Service;
using Repository;
using Models.Common;
using Service.Common;
using Repository.Common;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using Autofac;
using System.Reflection;
using AutoMapper;
using Oglasnik.WebAPI.AutoMapper;

namespace Oglasnik.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<Advert>().As<IAdvert>();
            builder.RegisterType<AdvertRepository>().As<IAdvertRepository>();
            builder.RegisterType<AdvertService>().As<IAdvertService>();


            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OrganizationProfile>();
            })).AsSelf().InstancePerRequest();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}