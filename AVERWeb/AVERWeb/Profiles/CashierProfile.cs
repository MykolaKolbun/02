using AutoMapper;
using AVERWeb.Dtos;
using AVERWeb.Models;

namespace AVERWeb.Profiles
{
    public class CashierProfile : Profile
    {
        public CashierProfile()
        {
            // Source -> Target
            CreateMap<Cashier, CashierReadDto>();
            CreateMap<CashierCreateDto, Cashier>();
            CreateMap<CashierUpdateDto, Cashier>();
        }
    }
}