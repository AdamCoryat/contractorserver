using System;
using System.Collections.Generic;
using contractorserver.Models;
using contractorserver.Repositories;

namespace contractorserver.Services
{
  public class JobsService
  {
      private readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Job> GetAll()
    {
        return _repo.GetAll();
    }

    internal Job GetById(int id)
    {
      var data =  _repo.GetById(id);
      if(data == null)
      {
        throw new Exception("Invalid ID");
      } 
      return data;
    }

    internal Job Create(Job newJob)
    {
      return _repo.Create(newJob);
    }

    internal Job Edit(Job updated)
    {
      var data = GetById(updated.Id);
      updated.Location = updated.Location != null ? updated.Location : data.Location;
      updated.Description = updated.Description != null ? updated.Description : data.Description;
      updated.ContactPhone = updated.ContactPhone > 0 ? updated.ContactPhone : data.ContactPhone;
      updated.StartDate = updated.StartDate != null ? updated.StartDate : data.StartDate;
      updated.TimeEst = updated.TimeEst != null ? updated.TimeEst : data.TimeEst;
      return _repo.Edit(updated);
    }

    internal String Delete(int id)
    {
      var data = GetById(id);
      _repo.Delete(id);
      return "Successfully Deleted!";
    }
  }
}