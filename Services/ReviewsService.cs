using System;
using System.Collections.Generic;
using contractorserver.Models;
using contractorserver.Repositories;

namespace contractorserver.Services
{
    public class ReviewsService
    {
      private readonly ReviewsRepository _repo;
      private readonly ContractorsRepository _conRepo;

    public ReviewsService(ReviewsRepository repo, ContractorsRepository conRepo)
    {
      _repo = repo;
      _conRepo = conRepo;
    }

    internal Review GetById(int id)
    {
      Review data = _repo.GetById(id);
      if(data == null)
      {
        throw new Exception("Invalid ID");
      }
      return data;
    }

    internal Review Create(Review newReview)
    {
      return _repo.Create(newReview);
    }

    internal Review Edit(Review update)
    {
      var original = GetById(update.Id);
      if(original == null)
      {
        throw new Exception("Bad Request");
      }
      update.ContractorId = original.ContractorId;
      update.Title = update.Title != null ? update.Title : original.Title;
      update.Body = update.Body != null ? update.Body : original.Body;
      update.DateStamp = update.DateStamp != null ? update.DateStamp : original.DateStamp;

      return _repo.Edit(update);
    }

    internal string Delete(int id)
    {
      var orginal = GetById(id);
      if(orginal == null)
      {
        throw new Exception("Invalid Id, Bad Request");
      }
      _repo.Delete(id);
      return "Sucessfully Deleted!";
    }

    internal IEnumerable<Review> GetByContractorId(int id)
    {
      var con = _conRepo.GetById(id);
      if (con == null)
      {
        throw new Exception("Inavlid Id");
      }
      return _repo.GetByContractorId(id);
    }
  }
}