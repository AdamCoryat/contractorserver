using System;
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
    [Authorize]
    public class BidsController : ControllerBase
    {
      private readonly BidsService _service;

    public BidsController(BidsService bs)
    {
      _service = bs;
    }
    
    [HttpPost]
    public async Task<ActionResult<string>> Create([FromBody] Bid newBid)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _service.Create(newBid, userInfo);
        return Ok("Success!");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _service.Delete(id, userInfo);
        return Ok("Success!");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}