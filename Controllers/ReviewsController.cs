using System;
using contractorserver.Models;
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

    [HttpGet("{id}")]
    public ActionResult<Review> Get(int id)
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
    [HttpPost]
    public ActionResult<Review> Create([FromBody] Review newReview)
    {
      try
      {
        return Ok(_service.Create(newReview));
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Review> Edit([FromBody] Review update, int id)
    {
      try
      {
        update.Id = id;
        return Ok(_service.Edit(update));
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Review> Delete(int id)
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