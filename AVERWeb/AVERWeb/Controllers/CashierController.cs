using AVERWeb.Data;
using AVERWeb.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AVERWeb.Dtos;

namespace AVERAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CashierController : ControllerBase
    {
        private readonly ICashierRepo _repository;
        private readonly IMapper _mapper;

        public CashierController(ICashierRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("fromcustomer/{customerId:int}", Name = "GetAllCashiers")]
        public ActionResult<IEnumerable<Cashier>> GetAllCashiers(int customerId)
        {
            Console.WriteLine($"--> Hit GetAllCashiers");
            var cashiersList = _repository.GetCashiersByCustomerId(customerId);
            if(cashiersList==null)
                return NotFound();
            else
                return Ok(cashiersList.Result);
        }


        [HttpGet("{cashierId:int}", Name = "GetCashier")]
        //[HttpGet("cashier/{id:int}")] // GET /api/test2/int/3
        public ActionResult <Cashier> GetCashier(int cashierId)
        {
            Console.WriteLine($"--> Hit GetCashier: {cashierId}");

            if (!_repository.CashierExist(cashierId))
            {
                return NotFound();
            }
            var cashier = _repository.GetCashierById(cashierId);
            return Ok(cashier.Result);
        }

        [HttpPost]
        public ActionResult<Cashier> CreateCashier(Cashier cashierCreateDto)
        {
            Console.WriteLine($"Hit CreateCashier");
            if(cashierCreateDto==null)
            {
                return BadRequest();
            }
            else
            {
                var cashierModel = _mapper.Map<Cashier>(cashierCreateDto);   // convert Read-DTO model to Database model
                _repository.CreateCashier(cashierModel);
                _repository.SaveChanges();
                var cashierReadDto = _mapper.Map<CashierReadDto>(cashierModel);
                return CreatedAtRoute(nameof(GetCashier), new {Id = cashierReadDto.Id}, cashierReadDto);
            }
        }

    }
}