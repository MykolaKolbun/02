using AutoMapper;
using AVERWeb.Data;
using AVERWeb.Dtos;
using AVERWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVERWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentTypeController : ControllerBase
{
    private readonly IPaymentTypeRepo _repository;
    private readonly IMapper _mapper;

    public PaymentTypeController(IPaymentTypeRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{id}", Name = "GetPaymentTypeById")]
    public ActionResult<PaymentType> GetPaymentTypeById(int id)
    {
        Console.WriteLine($"Hit Get PaymentType {id}");
        var paymentType = _repository.GetPaymentTypeById(id);    
        return Ok(paymentType.Result);
    }

    [HttpGet(Name = "GetAllPaymentTypes")]
    public ActionResult<IEnumerable<PaymentType>> GetAllPaymentTypes()
    {
        Console.WriteLine($"Hit Get All PaymentTypes");
        var PaymentTypeList = _repository.GetAllPaymentTypes();
        return Ok(PaymentTypeList.Result);
    }

    [HttpPost] 
    public ActionResult<PaymentTypeReadDto>CreatePaymentType(PaymentTypeCreateDto paymentTypeCreateDto)
    {
        Console.WriteLine($"Hit Create PaymentType");
        var paymentTypeModel = _mapper.Map<PaymentType>(paymentTypeCreateDto);
        _repository.CreatePaymentType(paymentTypeModel);
        _repository.SaveChanges();
        var paymentTypeReadDto = _mapper.Map<PaymentTypeReadDto>(paymentTypeModel);
        return CreatedAtRoute(nameof(GetPaymentTypeById), new { id = paymentTypeReadDto.Id}, paymentTypeReadDto);
    }
}    
