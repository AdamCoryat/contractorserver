using contractorserver.Repositories;

namespace contractorserver.Services
{
    public class ReviewsService
    {
      private readonly ReviewsRepository _repo;

    public ReviewsService(ReviewsRepository repo)
    {
      _repo = repo;
    }
  }
}