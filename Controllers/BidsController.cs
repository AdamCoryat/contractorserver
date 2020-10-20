using System;
using contractorserver.Models;
using contractorserver.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractorserver.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BidsController : ControllerBase
    {
      private readonly BidsService _service;

    public BidsController(BidsService bs)
    {
      _service = bs;
    }
    
    [HttpPost]
    public ActionResult<string> Create([FromBody] Bid newBid)
    {
      try
      {
        _service.Create(newBid);
        return Ok("Success!");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _service.Delete(id);
        return Ok("Success!");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}