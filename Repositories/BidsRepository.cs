using System.Data;

namespace contractorserver.Repositories
{
    public class BidsRepository
    {
      private readonly IDbConnection _db;

    public BidsRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}