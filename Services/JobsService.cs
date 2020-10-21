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

    internal Job GetById(int id, Profile userInfo)
    {
      var data =  _repo.GetById(id);
      if(data.CreatorId != userInfo.Id || data == null)
      {
        throw new Exception("No Permission or Invalid ID!");
      }
      return data;
    }

    internal Job Create(Job newJob, Profile userInfo)
    {
      if(newJob.CreatorId != userInfo.Id)
      {
        throw new Exception("Invalid Permissions");
      }
      return _repo.Create(newJob);
    }

    internal Job Edit(Job updated, Profile userInfo)
    {
      if(updated.CreatorId != userInfo.Id)
      {
        throw new Exception("Invalid Permissions to Edit");
      }
      var data = GetById(updated.Id, userInfo);
      updated.Location = updated.Location != null ? updated.Location : data.Location;
      updated.Description = updated.Description != null ? updated.Description : data.Description;
      updated.ContactPhone = updated.ContactPhone > 0 ? updated.ContactPhone : data.ContactPhone;
      updated.StartDate = updated.StartDate != null ? updated.StartDate : data.StartDate;
      updated.TimeEst = updated.TimeEst != null ? updated.TimeEst : data.TimeEst;
      return _repo.Edit(updated);
    }

    internal String Delete(int id, Profile userInfo)
    {

      var data = GetById(id, userInfo);
      if(data.CreatorId != userInfo.Id)
      {
        throw new Exception("Invalid Permissions to Delete");
      }
      _repo.Delete(id);
      return "Successfully Deleted!";
    }

    internal IEnumerable<JobBidViewModel> GetJobsByContractorId(int id)
    {
      return _repo.GetJobsByContractorId(id);
    }
  }
}