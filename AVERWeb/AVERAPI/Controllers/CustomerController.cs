using AVERWeb.Data;
using AVERWeb.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AVERWeb.Dtos;

namespace AVERAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CustomerController : ControllerBase
{
    private readonly ICustomerRepo customerRepo;
    private readonly IMapper mapper;

    public CustomerController(ICustomerRepo customerRepo, IMapper mapper)
    {
        this.customerRepo = customerRepo;
        this.mapper = mapper;
    }

    [HttpGet("{id}", Name = "GetCustomer")]
    public ActionResult<Customer> GetCustomer(int id)
    {
        Console.WriteLine($"Hit Get Customer {id}");
        var customer = customerRepo.GetCustomerById(id);
        return Ok(customer.Result);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetAllCustomers()
    {
        Console.WriteLine($"Hit Get All Customers");
        var customerList = customerRepo.GetAllCustomers();
        return Ok(customerList.Result);
    }

    [HttpPost]
    public ActionResult<CustomerReadDto> CreateCustomer(CustomerCreateDto customerCreateDto)
    {
        Console.WriteLine($"Hit Create Customer");
        var customerModel = mapper.Map<Customer>(customerCreateDto);
        customerRepo.CreateCustomer(customerModel);
        customerRepo.SaveChanges();
        var custromerReadDto = mapper.Map<CustomerReadDto>(customerModel);
        return CreatedAtRoute(nameof(GetCustomer), new {Id = custromerReadDto.Id}, custromerReadDto);
    }
}
