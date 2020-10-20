using System.Data;

namespace contractorserver.Repositories
{
    public class ReviewsRepository
    {
      private readonly IDbConnection _db;

    public ReviewsRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}