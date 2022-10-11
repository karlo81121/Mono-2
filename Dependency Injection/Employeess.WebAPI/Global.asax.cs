using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Employeess.Model;
using Employeess.Model.Common;
using Employeess.Repository;
using Employeess.Repository.Common;
using Employeess.Service;
using Employeess.Service.Common;
using Employeess.WebAPI.Controllers;
using Employeess.WebAPI.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Employeess.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ContainerBuilder builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();

            builder.RegisterType<Employee>().As<IEmployee>();
            builder.RegisterType<Salary>().As<ISalary>();

            builder.RegisterType<EmployeeRest>().As<IEmployeeRest>();
            builder.RegisterType<SalaryRest>().As<ISalaryRest>();

            builder.RegisterType<SalaryService>().As<ISalaryService>();
            builder.RegisterType<SalaryRepository>().As<ISalaryRepository>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiModelBinderProvider();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMappingProfile>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var cfg = context.Resolve<MapperConfiguration>();
                return cfg.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
