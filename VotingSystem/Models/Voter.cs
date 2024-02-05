
namespace VotingSystem.Models
{
    public class Voter
    {
        public int Id { get; set; }
        public string SSN { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public bool HasVoted { get; set; } = false;
        public List<Vote> Votes { get; set; } = new List<Vote>();
        public List<int> VotedPositionIds { get; set; } =  new List<int> { };

    }
}
