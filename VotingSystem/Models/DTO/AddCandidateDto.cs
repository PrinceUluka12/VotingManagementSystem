namespace VotingSystem.Models.DTO
{
    public class AddCandidateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        
        public int PositionId { get; set; }
    }
}
