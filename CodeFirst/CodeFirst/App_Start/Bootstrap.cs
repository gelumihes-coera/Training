using Autofac;
using Autofac.Integration.Mvc;
using CF.BusinessLayer.BusinessLogic;
using CF.BusinessLayer.Models;
using CF.DataAccessLayer.Models;
using CF.DataAccessLayer.Repositories;
using SOLIDapp.BusinessLayer.BusinessLogic;

namespace CodeFirst
{
    public class Bootstrap
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            //Controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Business Management
            builder.RegisterType<StudentManagement>().As<IBusinessManagement<StudentBusinessModel>>();
            builder.RegisterType<AddressManagement>().As<IBusinessManagement<AddressBusinessModel>>();

            //Repository
            builder.RegisterType<AddressRepository>().As<IRepository<Address>>();
            builder.RegisterType<StudentRepository>().As<IRepository<Student>>();

            return builder.Build();
        }
    }
}