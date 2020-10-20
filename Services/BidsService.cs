using contractorserver.Repositories;

namespace contractorserver.Services
{
    public class BidsService
    {
      private readonly BidsRepository _repo;

    public BidsService(BidsRepository repo)
    {
      _repo = repo;
    }
  }
}