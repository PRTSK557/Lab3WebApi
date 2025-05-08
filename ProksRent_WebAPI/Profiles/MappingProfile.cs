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
            CreateMap<Car, CarDto>()
                .ReverseMap()
                .ForMember(dest => dest.Brand, opt => opt.Ignore())
                .ForMember(dest => dest.FuelType, opt => opt.Ignore())
                .ForMember(dest => dest.TransmissionType, opt => opt.Ignore())
                .ForMember(dest => dest.Bookings, opt => opt.Ignore());
            CreateMap<FuelType, FuelTypeDto>().ReverseMap();
            CreateMap<TransmissionType, TransmissionTypeDto>().ReverseMap();
        }
    }
}