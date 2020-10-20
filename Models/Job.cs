namespace contractorserver.Models
{
    public class Job
    {
        public string Location { get; set; }
        public string Description { get; set; }
        public int ContactPhone { get; set; }
        public string StartDate { get; set; }
        public string TimeEst { get; set; }
        public int Id { get; set; }
    }
    public class JobBidViewModel : Job
    {
        public int BidId { get; set; }
        public double BidRate { get; set; }
    }
}