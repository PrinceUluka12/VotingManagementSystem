using System.ComponentModel.DataAnnotations.Schema;

namespace VotingSystem.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public int Votes { get; set; } = 0;
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position RunningFor { get; set; }
    }
}
