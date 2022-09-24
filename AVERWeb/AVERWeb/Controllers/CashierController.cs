using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
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

        [HttpGet]
        public ActionResult<IEnumerable<Cashier>> GetAllCashiers()
        {
            Console.WriteLine($"--> Hit GetAllCashiers");
            var cashiersList = _repository.GetCashiersByCustomerId(1);
            if(cashiersList==null)
                return NotFound();
            else
                return Ok(cashiersList.Result);
        }


        [HttpGet("{id}", Name = "GetCashier")]
        public ActionResult <Cashier> GetCashier(int id)
        {
            Console.WriteLine($"--> Hit GetCashier: {id}");

            if (!_repository.CashierExist(id))
            {
                return NotFound();
            }
            var cashier = _repository.GetCashierById(id);
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
                return CreatedAtRoute(nameof(GetCashier), new {Id = cashierReadDto.Id}, cashierReadDto);;
            }
        }

    }
}