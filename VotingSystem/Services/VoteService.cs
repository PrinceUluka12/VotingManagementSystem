using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;
using VotingSystem.Models;
using VotingSystem.Models.DTO;
using VotingSystem.Services.IServices;

namespace VotingSystem.Services
{
    public class VoteService : IVoteService
    {
        private readonly ICandidateService _candidateService;
        private readonly IVoterService _voterService;
        private readonly AppDbContext _db;
        public VoteService(ICandidateService candidateService, IVoterService voterService, AppDbContext db)
        {
                _candidateService = candidateService;
            _voterService = voterService;
            _db = db;
        }
        public async Task<(bool, string)> Vote(CastVoteDto castVote)
        {
            if (await _voterService.AuthenticateVoter(castVote.VoterUserName, castVote.VoterSsn))
            {
                var voter = await _db.Voters.Include(v => v.Votes).FirstOrDefaultAsync(v => v.UserName == castVote.VoterUserName);
                if(voter != null && !voter.HasVoted && !voter.VotedPositionIds.Contains(castVote.PositionId))
                {
                    var candidate = await _db.Candidates.FirstOrDefaultAsync(c => c.Id == castVote.CandidateId && c.RunningFor.Id == castVote.PositionId);
                    if (candidate != null)
                    {
                        var vote = new Vote
                        {
                            CandidateId = castVote.CandidateId,
                            VoterId = voter.Id,
                        };
                        await _db.Votes.AddAsync(vote);
                        candidate.Votes++;
                        voter.HasVoted = true;
                        voter.VotedPositionIds.Add(castVote.PositionId);
                        await _db.SaveChangesAsync();
                        return (true, $"Vote for {voter.FirstName}, {voter.LastName} recorded!");
                    }
                    else
                    {
                        return (false, "Invalid candidate ID or position ID.");
                    }
                }
                else
                {
                    return (false, "You have already voted or invalid voter.");
                }
            }
            else
            {
                return (false, "Invalid username. Authentication failed.");
            }
           
        }
    }
}
