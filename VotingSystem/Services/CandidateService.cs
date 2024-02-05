using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;
using VotingSystem.Models;
using VotingSystem.Models.DTO;
using VotingSystem.Services.IServices;

namespace VotingSystem.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly AppDbContext _db;
        private readonly IPositionService _positionService;
        public CandidateService(AppDbContext db, IPositionService positionService)
        {
            _db = db;
            _positionService = positionService;
        }
        public async Task<(bool, string)> AddCandidate(AddCandidateDto candidate)
        {
            try
            {
                var positionCheck = await _positionService.GetPositionById(candidate.PositionId);
                var candidateCheck = await _db.Candidates.FirstOrDefaultAsync(c => c.SSN == candidate.SSN);

                if (positionCheck.Item1 == false)
                {
                    return (false, "Position Selected does not exist");
                }else if (candidateCheck != null)
                {
                    return (false, "Candidate is already registered");
                }
                else
                {
                    Candidate newCandidate = new Candidate()
                    {
                        SSN = candidate.SSN,
                        RunningFor = positionCheck.Item2,
                        FirstName = candidate.FirstName,
                        LastName = candidate.LastName,
                        Votes = 0,
                        PositionId = candidate.PositionId,
                    };

                    await _db.Candidates.AddAsync(newCandidate);
                    await _db.SaveChangesAsync();
                    return (true, "Candidate registered successfully");
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool,Candidate)> GetCandidateById(int Id)
        {
            try
            {
                var data = await _db.Candidates.FirstOrDefaultAsync(c => c.Id == Id);
                if (data != null)
                {
                    return (true, data);
                }
                else
                {
                    return (false, new Candidate());
                }
            }
            catch (Exception)
            {

                return (false, new Candidate());
            }
        }

        public async Task<List<Candidate>> GetCandidatesByPositionId(int positionId)
        {
            try
            {
                var data = await _db.Candidates.Where(p => p.RunningFor.Id == positionId).ToListAsync();
                return data;
            }
            catch (Exception)
            {

                return new List<Candidate>();
            }
        }
    }
}
