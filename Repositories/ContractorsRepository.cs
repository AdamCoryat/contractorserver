using System;
using System.Collections.Generic;
using System.Data;
using contractorserver.Models;
using Dapper;

namespace contractorserver.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Contractor> GetAll()
    {
      string sql = @"
      SELECT
      c.*,
      p.*
      FROM contractors c
      JOIN profiles p ON c.creatorId = p.id";
    return _db.Query<Contractor, Profile, Contractor>(sql, (contractor, profile) => 
    {
      contractor.Creator = profile;
      return contractor;
    }, splitOn: "id");
    }

    internal Contractor GetById(int id)
    {
      string sql = "SELECT * FROM contractors WHERE id = @id LIMIT 1";
      return _db.QueryFirstOrDefault<Contractor>(sql, new {id});
    }

    internal Contractor Create(Contractor newCon)
    {
      string sql = @"
      INSERT INTO contractors
      (name, address, contactPhone, creatorId)
      VALUES
      (@Name, @Address, @ContactPhone, @CreatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newCon);
      newCon.Id = id;
      return newCon;
    }

    internal Contractor Edit(Contractor updated)
    {
      string sql = @"
        UPDATE contractors
        SET
          name = @Name,
          address = @Address,
          contactPhone = @ContactPhone
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM contractors WHERE id = @id LIMIT 1";
      _db.Execute(sql, new {id});
    }
  }
}