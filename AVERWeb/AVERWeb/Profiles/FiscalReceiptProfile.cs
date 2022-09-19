using AutoMapper;
using AVERWeb.Dtos;
using AVERWeb.Models;

namespace AVERWeb.Profiles
{
    public class FiscalReceiptProfile : Profile
    {
        public FiscalReceiptProfile()
        {
            // Source -> Target
            CreateMap<FiscalReceipt, FiscalReceiptReadDto>();
            CreateMap<FiscalReceiptCreateDto, FiscalReceipt>();
            CreateMap<FiscalReceiptUpdateDto, FiscalReceipt>();
        }
    }
}