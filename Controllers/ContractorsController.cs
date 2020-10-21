using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using contractorserver.Models;
using contractorserver.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace contractorserver.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ContractorsController : ControllerBase
    {
      private readonly ContractorsService _service;
      private readonly ReviewsService _revService;
      private readonly JobsService _jobService;

    public ContractorsController(ContractorsService cs, ReviewsService rs, JobsService js)
    {
      _service = cs;
      _revService = rs;
      _jobService = js;
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
    [HttpGet("{id}/jobs")]
    public ActionResult<IEnumerable<JobBidViewModel>> GetJobs(int id)
    {
      try
      {
        return Ok(_jobService.GetJobsByContractorId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Contractor>> Create([FromBody] Contractor newCon)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newCon.CreatorId = userInfo.Id;
        return Ok(_service.Create(newCon));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Contractor>> Edit([FromBody] Contractor updated, int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        updated.CreatorId = userInfo.Id;
        updated.Id = id;
        return Ok(_service.Edit(updated));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Contractor>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    
    }
}