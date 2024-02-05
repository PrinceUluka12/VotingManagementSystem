using VotingSystem.Models;
using VotingSystem.Models.DTO;

namespace VotingSystem.Services.IServices
{
    public interface ICandidateService
    {
        Task<(bool, string)> AddCandidate(AddCandidateDto candidate);
        Task<(bool, Candidate)> GetCandidateById(int Id);
        Task<List<Candidate>> GetCandidatesByPositionId(int position);

    }
}
