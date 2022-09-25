using AutoMapper;
using AVERWeb.Dtos;
using AVERWeb.Models;

namespace AVERWeb.Profiles
{
    public class CertificateProfile : Profile
    {
        public CertificateProfile()
        {
            // Source -> Target
            CreateMap<Certificate, CertificateReadDto>();
            CreateMap<CertificateCreateDto, Certificate>();
            CreateMap<CertificateUpdateDto, Certificate>();
        }
    }
}