namespace VotingSystem.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Candidate> Candidates { get; set; } =  new List<Candidate>();
    }
}
