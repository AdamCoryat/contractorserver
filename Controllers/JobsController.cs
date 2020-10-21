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
    public class JobsController : ControllerBase
    {
        private readonly JobsService _service;
        private readonly ContractorsService _conService;

    public JobsController(JobsService js, ContractorsService cs)
    {
      _service = js;
      _conService = cs;
    }

    [HttpGet]
    public ActionResult<Job> Get()
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
    [Authorize]
    public async Task<ActionResult<Job>> Get(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.GetById(id, userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/contractors")]
    public ActionResult<IEnumerable<ContractorBidViewModel>> GetContractors(int id)
    {
      try
      {
        return Ok(_conService.GetContractorsByJobId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Job>> Create([FromBody] Job newJob)
    {
        try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.Create(newJob, userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Job>> Edit([FromBody] Job updated, int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        updated.Id = id;
        return Ok(_service.Edit(updated, userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Job>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.Delete(id, userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}