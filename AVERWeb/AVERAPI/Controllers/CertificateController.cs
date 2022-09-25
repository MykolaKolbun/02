using AutoMapper;
using AVERWeb.Data;
using AVERWeb.Dtos;
using AVERWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVERWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CertificateController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICertificateRepo _repository;

    public CertificateController(ICertificateRepo repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [HttpGet("{id}", Name = "GetCertificate")]
    public ActionResult<Certificate> GetCertificate(int id)
    {
        Console.WriteLine($"Hit Get Certificate {id}");
        var certificate = _repository.GetCertificate(id);
        return Ok(certificate.Result);
    }

    [HttpGet("fromcashier/{cashierId:int}", Name = "GetAllCertificates")]
    public ActionResult<IEnumerable<Certificate>> GetAllCertificates(int id)
    {
        Console.WriteLine($"Hit Get All Cashier's Certificates");
        var certificateList = _repository.GetCertificatesByCashierID(id);
        return Ok(certificateList.Result);
    }

    [HttpPost] 
    public ActionResult<CertificateReadDto>CreateCertificate(CertificateCreateDto certificateCreateDto)
    {
        Console.WriteLine($"Hit Create Certificate");
        var certificateModel = _mapper.Map<Certificate>(certificateCreateDto);
        _repository.CreateCertificate(certificateModel);
        _repository.SaveChanges();
        var certificateReadDto = _mapper.Map<CertificateReadDto>(certificateModel);
        return CreatedAtRoute(nameof(GetCertificate), new {Id = certificateReadDto.Id}, certificateReadDto);
    }

}