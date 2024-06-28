using AutoMapper;
using System;
using unittesting.Entities;
using unittesting.Models;

namespace unittesting.AutoMapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
           //test
            CreateMap<Customer, CustomerModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));
            CreateMap<Order, OrderModel>().ReverseMap();
         
        }
    }
}
