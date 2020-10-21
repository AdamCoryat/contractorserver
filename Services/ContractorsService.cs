using System;
using System.Collections.Generic;
using contractorserver.Models;
using contractorserver.Repositories;

namespace contractorserver.Services
{
  public class ContractorsService
  {
      private readonly ContractorsRepository _repo;

    public ContractorsService(ContractorsRepository repo)
    {
        _repo = repo;
    }

    internal IEnumerable<Contractor> GetAll()
    {
      return _repo.GetAll();
    }

    internal Contractor GetById(int id)
    {
      var data = _repo.GetById(id);
      if(data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Contractor Create(Contractor newCon)
    {
      return _repo.Create(newCon);
    }

    internal Contractor Edit(Contractor updated)
    {
      var data = GetById(updated.Id);
      if(data.CreatorId != updated.CreatorId)
      {
        throw new Exception("Invalid Creator you do not have permissions");
      }
      updated.Name = updated.Name != null ? updated.Name : data.Name;
      updated.Address = updated.Address != null ? updated.Address : data.Address;
      updated.ContactPhone = updated.ContactPhone > 0 ? updated.ContactPhone : data.ContactPhone;
      return _repo.Edit(updated);
    }

    internal String Delete(int id, string userId)
    {
      var data = GetById(id);
      if(data.CreatorId != userId)
      {
        throw new Exception("Invalid Creator you do not have permissions");
      }
      _repo.Delete(id);
      return "Successfully Deleted";
    }

    internal IEnumerable<ContractorBidViewModel> GetContractorsByJobId(int id)
    {
     return _repo.GetContractorsByJobId(id);
    }
  }
}