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
  }
}