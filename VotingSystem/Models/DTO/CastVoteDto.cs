namespace VotingSystem.Models.DTO
{
    public class CastVoteDto
    {
        public string VoterUserName { get; set; }
        public string VoterSsn { get; set; }
        public int PositionId { get; set; }
        public int CandidateId { get; set; }
    }
}
