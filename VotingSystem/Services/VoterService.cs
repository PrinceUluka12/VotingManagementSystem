using Microsoft.EntityFrameworkCore;
using NLog;
using VotingSystem.Data;
using VotingSystem.Models;
using VotingSystem.Models.DTO;
using VotingSystem.Services.IServices;

namespace VotingSystem.Services
{
    public class VoterService : IVoterService
    {
        private readonly AppDbContext _db;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public VoterService(AppDbContext db)
        {
                _db = db;
        }
        public async Task<(bool,string)> AddVoter(AddVoterDto voter)
        {
            try
            {
                var checkUserName = await _db.Voters.FirstOrDefaultAsync(v => v.UserName == voter.UserName);
                var checkSSN = await _db.Voters.FirstOrDefaultAsync(v => v.SSN == voter.SSN);

                if (checkUserName != null)
                {
                    logger.Error($"{voter.UserName} - Username already Exists");
                    return (false, "Username Already Exists");
                }else if(checkSSN != null)
                {
                    return (false, "Voter is already registered");
                }
                else
                {
                    Voter newVoter = new Voter()
                    {
                        DOB =  voter.DOB,
                        FirstName = voter.FirstName,
                        LastName = voter.LastName,
                        SSN = voter.SSN,
                        UserName = voter.UserName,
                        
                    };
                    await _db.Voters.AddAsync(newVoter);
                    await _db.SaveChangesAsync();
                    return (true, "Successfully Registered Voter");
                }
            }
            catch (Exception ex)
            {

                return (false,ex.Message);
            }
        }

        public async Task<bool> AuthenticateVoter(string username, string ssn)
        {
            try
            {
                var voter = await _db.Voters.FirstOrDefaultAsync(a => a.UserName == username && a.SSN == ssn);
                if (voter != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<(bool, List<Voter>)> GetAllVoters()
        {
            try
            {
                var data =  await _db.Voters.ToListAsync();
                return (true,  data);
            }
            catch (Exception)
            {

                return (false, new List<Voter>());
            }
        }

        public async Task<(bool, Voter)> GetVoterById(int Id)
        {
            try
            {
                var data = await _db.Voters.FirstOrDefaultAsync(c => c.Id == Id);
                if (data != null)
                {
                    return (true, data);
                }
                else
                {
                    return (false, new Voter());
                }
            }
            catch (Exception)
            {

                return (false, new Voter());
            }
        }

        public async  Task<(bool, Voter)> GetVoterByUsername(string username)
        {
            try
            {
                var data = await _db.Voters.FirstOrDefaultAsync(c => c.UserName == username);
                if (data != null)
                {
                    return (true, data);
                }
                else
                {
                    return (false, new Voter());
                }
            }
            catch (Exception)
            {

                return (false, new Voter());
            }
        }
    }
}
