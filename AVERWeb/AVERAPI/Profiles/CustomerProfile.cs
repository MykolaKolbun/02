using AutoMapper;
using AVERWeb.Dtos;
using AVERWeb.Models;

namespace AVERWeb.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // Source -> Target
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
        }
    }
}