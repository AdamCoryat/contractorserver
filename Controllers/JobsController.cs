using contractorserver.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractorserver.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _service;

    public JobsController(JobsService js)
    {
      _service = js;
    }
  }
}