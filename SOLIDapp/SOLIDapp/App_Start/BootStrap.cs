using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using SOLIDapp.BusinessLayer;
using SOLIDapp.BusinessLayer.BusinessLogic;
using SOLIDapp.BusinessLayer.BusinessModels;
using SOLIDapp.Controllers;
using SOLIDapp.DataLayer.Repositories;
using SOLIDapp.Log4Net;

namespace SOLIDapp
{
    public enum Names
    {
        Ingredient, Product, Order, Customer
    }

    public class BootStrap
    {
        public static IContainer BuildContainer(Log4NetLogger logger)
        {
            var builder = new ContainerBuilder();

            //Logger
            builder.RegisterInstance<ILogger>(logger);
            builder.Register(c => logger).As<ILogger>().SingleInstance();

            //Controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Business Management
            builder.RegisterType<CustomerManagementBl>().As<IBusinessManagement<CustomerBusinessModel>>();
            builder.RegisterType<IngredientManagementBl>().As<IBusinessManagement<IngredientBusinessModel>>();
            builder.RegisterType<ProductManagementBl>().As< IBusinessManagement<ProductBusinessModel>>();
            builder.RegisterType<OrderManagementBl>().As<IBusinessManagement<OrderBusinessModel>>();
            builder.RegisterType<OrderItemManagementBl>().As<IBusinessManagement<OrderItemBusinessModel>>();
            builder.RegisterType<StorageManagementBl>().As<IBusinessManagement<StorageBusinessModel>>();

            //Repository
            builder.RegisterType<Repository>().As<IRepository>();

            return builder.Build();
        }
    }
}
