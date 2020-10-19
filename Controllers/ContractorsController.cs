using System;
using contractorserver.Models;
using contractorserver.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractorserver.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ContractorsController : ControllerBase
    {
      private readonly ContractorsService _service;

    public ContractorsController(ContractorsService cs)
    {
      _service = cs;
    }

    [HttpGet]
    public ActionResult<Contractor> Get()
    {
      try
      {
          return Ok(_service.GetAll());
      }
      catch (Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    
    }
}