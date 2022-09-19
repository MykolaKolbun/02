using AutoMapper;
using AVERWeb.Dtos;
using AVERWeb.Models;

namespace AVERWeb.Profiles
{
    public class MachineTypeProfile : Profile
    {
        public MachineTypeProfile()
        {
            // Source -> Target
            CreateMap<MachineType, MachineTypeReadDto>();
            CreateMap<MachineTypeCreateDto, MachineType>();
            CreateMap<MachineTypeUpdateDto, MachineType>();
        }
    }
}