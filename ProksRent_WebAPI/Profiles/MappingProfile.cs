using AutoMapper;
using PROKSRent_WebAPI.Models;
using ProksRent_WebAPI.DTOs;
using ProksRent_WebAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProksRent_WebAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<FuelType, FuelTypeDto>().ReverseMap();
            CreateMap<TransmissionType, TransmissionTypeDto>().ReverseMap();
        }
    }
}