using System;
using System.Data;
using contractorserver.Models;
using Dapper;

namespace contractorserver.Repositories
{
    public class BidsRepository
    {
      private readonly IDbConnection _db;

    public BidsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal void Create(Bid newBid)
    {
      string sql = @"
      INSERT INTO bids
      (jobId, contractorId, bidPrice, creatorId)
      VALUES
      (@JobId, @ContractorId, @BidPrice, @CreatorId);";
      _db.Execute(sql, newBid);
    }

    internal Bid GetById(int id)
    {
      string sql = "SELECT * FROM bids WHERE id = @id;";
      return _db.QueryFirstOrDefault<Bid>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM bids WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}