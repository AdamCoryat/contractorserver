using System;
using System.Collections.Generic;
using System.Data;
using contractorserver.Models;
using Dapper;

namespace contractorserver.Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Job> GetAll()
    {
      string sql = @"
        SELECT
        j.*,
        p.*
        FROM jobs j
        JOIN profiles p ON j.creatorId = p.id";
      return _db.Query<Job, Profile, Job>(sql, (job, profile)=> 
      {
        job.Creator = profile;
        return job;
      }, splitOn: "id");
      
    }

    internal Job GetById(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @id LIMIT 1";
      return _db.QueryFirstOrDefault<Job>(sql, new {id});
    }

    internal Job Create(Job newJob)
    {
      string sql = @"
      INSERT INTO jobs
      (location, description, contactPhone, startDate, timeEst, creatorId)
      VALUES
      (@Location, @Description, @ContactPhone, @StartDate, @TimeEst, @CreatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newJob);
      newJob.Id = id;
      return newJob;
    }

    internal Job Edit(Job updated)
    {
      string sql = @"
      UPDATE jobs
      SET
        location = @Location,
        description = @Description,
        contactPhone = @ContactPhone,
        startDate = @StartDate,
        timeEst = @TimeEst
      WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM jobs WHERE id = @id";
      _db.Execute(sql, new {id});
    }

    internal IEnumerable<JobBidViewModel> GetJobsByContractorId(int id)
    {
      string sql = @"
      SELECT
      j.*,
      b.id AS BidId
      FROM bids b
      JOIN jobs j ON j.id = b.jobId
      WHERE contractorId = @id
      ";
      return _db.Query<JobBidViewModel>(sql, new { id });
    }
  }
}