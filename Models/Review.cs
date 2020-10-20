namespace contractorserver.Models
{
    public class Review
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Rating { get; set; }
        public string Date { get; set; }
        public int ContractorId { get; set; }
    }
}