using System;
using System.Collections.Generic;
using contractorserver.Models;
using contractorserver.Repositories;

namespace contractorserver.Services
{
  public class ContractorsService
  {
      private readonly ContractorsRepository _reop;

    public ContractorsService(ContractorsRepository repo)
    {
        _reop = repo;
    }

    internal IEnumerable<Contractor> GetAll()
    {
      return _reop.GetAll();
    }
  }
}