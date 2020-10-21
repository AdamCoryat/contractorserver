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

    internal void Create(Bid newBid, Profile userInfo)
    {
      if(newBid.CreatorId != userInfo.Id)
      {
        throw new Exception("Invalid Permissions UnAuthorized");
      }
      _repo.Create(newBid);
    }

    internal void Delete(int id, Profile userInfo)
    {
      var data = _repo.GetById(id);
      if(data.CreatorId != userInfo.Id)
      {
        throw new Exception("Invalid Permissions to Delete");
      }
      _repo.Delete(id);
    }
  }
}