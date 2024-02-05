using VotingSystem.Models.DTO;

namespace VotingSystem.Services.IServices
{
    public interface IVoteService
    {
        Task<(bool, string)> Vote(CastVoteDto castVote);
    }
}
