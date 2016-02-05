using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using CF.DataAccessLayer;
using CF.DataAccessLayer.Models;

namespace CodeFirst
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.Initialize();

            _container = Bootstrap.BuildContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }
    }
}
