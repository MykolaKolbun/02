using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AVERWeb.Data;
using AVERWeb.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AVERWeb.Dtos;

namespace AVERAPI.Controllers
{
    [ApiController]
    [Route("apiV1/test/[controller]")]
    public class CashierController : ControllerBase
    {
        private readonly ICashierRepo _repository;
        private readonly IMapper _mappper;

        public CashierController(ICashierRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mappper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cashier>> GetAllCashiers()
        {
            Console.WriteLine($"--> Hit GetAllCashiers");
            var cashiersList = _repository.GetCashiersByCucsstomerId(1);
            return Ok();
        }


        [HttpGet("{casherid}")]
        public ActionResult GetCashier(int cashierId)
        {
/*
            var commandItem = _repository.GetCommandById(id);
            if(commandItem!=null)
            {
                //return Ok(commandItem);  w/o DTOs
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
*/
            Console.WriteLine($"--> Hit GetCashier: {cashierId}");

            if (!_repository.CashierExist(cashierId))
            {
                return NotFound();
            }
            var cashier = _repository.GetCashierById(cashierId);
            return Ok(_mappper.Map<CashierReadDto>(cashier));
        }


    }
}