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
      updated.Name = updated.Name != null ? updated.Name : data.Name;
      updated.Address = updated.Address != null ? updated.Address : data.Address;
      updated.ContactPhone = updated.ContactPhone > 0 ? updated.ContactPhone : data.ContactPhone;
      return _repo.Edit(updated);
    }

    internal String Delete(int id)
    {
      var data = GetById(id);
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}