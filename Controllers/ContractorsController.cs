using System;
using System.Collections.Generic;
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
      private readonly ReviewsService _revService;

    public ContractorsController(ContractorsService cs, ReviewsService rs)
    {
      _service = cs;
      _revService = rs;
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

    [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception e)
      {
       return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/reviews")]
    public ActionResult<IEnumerable<Review>> GetReviews(int id)
    {
      try
      {
        return Ok(_revService.GetByContractorId(id));
      }
      catch (Exception e) 
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor newCon)
    {
      try
      {
        return Ok(_service.Create(newCon));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Contractor> Edit([FromBody] Contractor updated, int id)
    {
      try
      {
        updated.Id = id;
        return Ok(_service.Edit(updated));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Contractor> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    
    }
}