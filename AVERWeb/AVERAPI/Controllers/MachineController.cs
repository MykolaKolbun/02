using AutoMapper;
using AVERWeb.Data;
using AVERWeb.Dtos;
using AVERWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVERWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MachineController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMachineRepo _repository;

    public MachineController(IMachineRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{id}", Name = "GetMachineById")]
    public ActionResult<Machine> GetMachineById(int id)
    {
        Console.WriteLine($"Hit Get Machine {id}");
        var machine = _repository.GetMachineById(id);    
        return Ok(machine.Result);
    }

    [HttpGet(Name = "GetAllMachines")]
    public ActionResult<IEnumerable<Machine>> GetAllMachines()
    {
        Console.WriteLine($"Hit Get All Machines");
        var machineList = _repository.GetAllMachine();
        return Ok(machineList.Result);
    }

    [HttpPost] 
    public ActionResult<MachineReadDto>CreateMachine(MachineCreateDto machineCreateDto)
    {
        Console.WriteLine($"Hit Create Machine");
        var machineModel = _mapper.Map<Machine>(machineCreateDto);
        _repository.CreateMachine(machineModel);
        _repository.SaveChanges();
        var machineReadDto = _mapper.Map<MachineReadDto>(machineModel);
        return CreatedAtRoute(nameof(GetMachineById), new { id = machineReadDto.Id}, machineReadDto);
    }
}