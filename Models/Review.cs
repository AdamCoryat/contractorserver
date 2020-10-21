using System.ComponentModel.DataAnnotations;

namespace contractorserver.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
        public string DateStamp { get; set; }
        public int ContractorId { get; set; }
        public string CreatorId { get; set; }
    }
}