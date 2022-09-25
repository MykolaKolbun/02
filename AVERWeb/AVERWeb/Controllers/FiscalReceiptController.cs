using AutoMapper;
using AVERWeb.Data;
using AVERWeb.Dtos;
using AVERWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVERWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FiscalReceiptController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IFiscalReceiptRepo _repository;

    public FiscalReceiptController(IFiscalReceiptRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{id}", Name = "GetFiscalReceiptById")]
    public ActionResult<FiscalReceipt> GetFiscalReceiptById(int id)
    {
        Console.WriteLine($"Hit Get FiscalReceipt {id}");
        var fiscalReceipt = _repository.GetFiscalReceiptById(id);    
        return Ok(fiscalReceipt.Result);
    }

    [HttpPost] 
    public ActionResult<FiscalReceiptReadDto>CreatePaymentType(FiscalReceiptCreateDto fiscalReceiptCreateDto)
    {
        Console.WriteLine($"Hit Create PaymentType");
        var fiscalReceiptModel = _mapper.Map<FiscalReceipt>(fiscalReceiptCreateDto);
        _repository.CreateFiscalReceipt(fiscalReceiptModel);
        _repository.SaveChanges();
        var fiscalReceiptReadDto = _mapper.Map<PaymentTypeReadDto>(fiscalReceiptModel);
        return CreatedAtRoute(nameof(GetFiscalReceiptById), new { id = fiscalReceiptReadDto.Id}, fiscalReceiptReadDto);
    }
}