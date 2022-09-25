using AutoMapper;
using AVERWeb.Data;
using AVERWeb.Dtos;
using AVERWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVERWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MachineTypeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMachineTypeRepo _repository;

    public MachineTypeController(IMachineTypeRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{id}", Name = "GetMachineTypeById")]
    public ActionResult<MachineType> GetMachineTypeById(int id)
    {
        Console.WriteLine($"Hit Get MachineType {id}");
        var machineType = _repository.GetMachineTypeById(id);    
        return Ok(machineType.Result);
    }

    [HttpGet(Name = "GetAllMachineTypes")]
    public ActionResult<IEnumerable<MachineType>> GetAllMachineTypes()
    {
        Console.WriteLine($"Hit Get All MachineTypes");
        var machineTypeList = _repository.GetAllMachineTypes();
        return Ok(machineTypeList.Result);
    }

    [HttpPost] 
    public ActionResult<MachineTypeReadDto>CreatePaymentType(MachineTypeCreateDto machineTypeCreateDto)
    {
        Console.WriteLine($"Hit Create PaymentType");
        var machineTypeModel = _mapper.Map<MachineType>(machineTypeCreateDto);
        _repository.CreateMachineType(machineTypeModel);
        _repository.SaveChanges();
        var machineTypeReadDto = _mapper.Map<PaymentTypeReadDto>(machineTypeModel);
        return CreatedAtRoute(nameof(GetMachineTypeById), new { id = machineTypeReadDto.Id}, machineTypeReadDto);
    }
}