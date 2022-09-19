using AutoMapper;
using AVERWeb.Dtos;
using AVERWeb.Models;

namespace AVERWeb.Profiles
{
    public class PaymentTypeProfile : Profile
    {
        public PaymentTypeProfile()
        {
            // Source -> Target
            CreateMap<PaymentType, PaymentTypeReadDto>();
            CreateMap<PaymentTypeCreateDto, PaymentType>();
            CreateMap<PaymentTypeUpdateDto, PaymentType>();
        }
    }
}