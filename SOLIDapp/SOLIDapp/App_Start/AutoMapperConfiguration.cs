using AutoMapper;
using SOLIDapp.BusinessLayer.BusinessLogic;
using SOLIDapp.BusinessLayer.BusinessModels;
using SOLIDapp.DataLayer;
using SOLIDapp.Models;

namespace SOLIDapp
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            //Product
            Mapper.CreateMap<ProductViewModel, ProductBusinessModel>().ReverseMap();
            Mapper.CreateMap<ProductBusinessModel, Product>().ReverseMap();

            //Customer
            Mapper.CreateMap<CustomerViewModel, CustomerBusinessModel>().ReverseMap();
            Mapper.CreateMap<CustomerBusinessModel, Customer>().ReverseMap();

            //Ingredient
            Mapper.CreateMap<IngredientViewModel, IngredientBusinessModel>().ReverseMap();
            Mapper.CreateMap<IngredientBusinessModel, Ingredient>().ReverseMap();

            //Order
            Mapper.CreateMap<OrderViewModel, OrderBusinessModel>().ReverseMap();
            Mapper.CreateMap<OrderBusinessModel, Order>().ReverseMap();

            //Storage
            Mapper.CreateMap<StorageViewModel, StorageBusinessModel>().ReverseMap();
            Mapper.CreateMap<StorageBusinessModel, Storage>().ReverseMap();
        }
    }
}