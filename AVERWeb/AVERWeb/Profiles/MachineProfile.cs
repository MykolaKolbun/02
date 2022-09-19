using AutoMapper;
using AVERWeb.Dtos;
using AVERWeb.Models;

namespace AVERWeb.Profiles
{
    public class MachineProfile : Profile
    {
        public MachineProfile()
        {
            // Source -> Target
            CreateMap<Machine, MachineReadDto>();
            CreateMap<MachineCreateDto, Machine>();
            CreateMap<MachineUpdateDto, Machine>();
        }
    }
}