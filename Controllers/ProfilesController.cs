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
    [Route("api/[controller]")]

    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _ps;

    public ProfilesController(ProfilesService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));   
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}