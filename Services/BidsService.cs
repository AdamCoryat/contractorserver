using System;
using contractorserver.Models;
using contractorserver.Repositories;

namespace contractorserver.Services
{
    public class BidsService
    {
      private readonly BidsRepository _repo;

    public BidsService(BidsRepository repo)
    {
      _repo = repo;
    }

    internal void Create(Bid newBid)
    {
      _repo.Create(newBid);
    }

    internal void Delete(int id)
    {
      var data = _repo.GetById(id);
      if(data == null)
      {
        throw new Exception("Inavlid Id");
      }
      _repo.Delete(id);
    }
  }
}