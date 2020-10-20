using contractorserver.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractorserver.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewsService _service;

    public ReviewsController(ReviewsService rs)
    {
      _service = rs;
    }
  }
}