using VotingSystem.Models;

namespace VotingSystem.Services.IServices
{
    public interface IVoterService
    {
        Task<(bool, string)> AddVoter(Voter voter);
        Task<(bool, Voter)> GetVoterById(int Id);
        Task<(bool, Voter)> GetVoterByUsername(string username);
        Task<bool> AuthenticateVoter(string username, string ssn);
    }
}
