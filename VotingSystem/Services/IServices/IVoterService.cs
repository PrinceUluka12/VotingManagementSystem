using VotingSystem.Models;
using VotingSystem.Models.DTO;

namespace VotingSystem.Services.IServices
{
    public interface IVoterService
    {
        Task<(bool, string)> AddVoter(AddVoterDto voter);
        Task<(bool, List<Voter>)> GetAllVoters();
        Task<(bool, Voter)> GetVoterById(int Id);
        Task<(bool, Voter)> GetVoterByUsername(string username);
        Task<bool> AuthenticateVoter(string username, string ssn);
    }
}
