using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;
using VotingSystem.Models;
using VotingSystem.Services.IServices;

namespace VotingSystem.Services
{
    public class VoterService : IVoterService
    {
        private readonly AppDbContext _db;
        public VoterService(AppDbContext db)
        {
                _db = db;
        }
        public async Task<(bool,string)> AddVoter(Voter voter)
        {
            try
            {
                var checkUserName = await _db.Voters.FirstOrDefaultAsync(v => v.UserName == voter.UserName);
                var checkSSN = await _db.Voters.FirstOrDefaultAsync(v => v.SSN == voter.SSN);

                if (checkUserName != null)
                {
                    return (false, "Username Already Exists");
                }else if(checkSSN != null)
                {
                    return (false, "Voter is already registered");
                }
                else
                {
                    await _db.Voters.AddAsync(voter);
                    await _db.SaveChangesAsync();
                    return (true, "Successfully Registered Voter");
                }
            }
            catch (Exception ex)
            {

                return (false,"");
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
