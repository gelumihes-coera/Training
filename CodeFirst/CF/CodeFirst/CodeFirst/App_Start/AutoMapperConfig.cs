using AutoMapper;
using CF.BusinessLayer.Models;
using CF.DataAccessLayer.Models;
using CodeFirst.Models;

namespace CodeFirst
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            //Student
            Mapper.CreateMap<StudentViewModel, StudentBusinessModel>().ReverseMap();
            Mapper.CreateMap<StudentBusinessModel, Student>().ReverseMap();

            //Address
            Mapper.CreateMap<AddressViewModel, AddressBusinessModel>().ReverseMap();
            Mapper.CreateMap<AddressBusinessModel, Address>().ReverseMap();
        }
    }
}