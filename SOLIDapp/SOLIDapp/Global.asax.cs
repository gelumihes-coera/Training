using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using SOLIDapp.Log4Net;

namespace SOLIDapp
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

            AutoMapperConfiguration.Initialize();

            Log4NetLogger logger = new Log4NetLogger();

            _container = BootStrap.BuildContainer(logger);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }
    }
}
