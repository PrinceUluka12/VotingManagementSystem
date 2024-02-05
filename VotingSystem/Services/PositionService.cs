using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;
using VotingSystem.Models;
using VotingSystem.Models.DTO;
using VotingSystem.Services.IServices;

namespace VotingSystem.Services
{
    public class PositionService : IPositionService
    {
        private readonly AppDbContext _db;
        public PositionService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<(bool, string)> AddPosition(AddPositionDto position)
        {
            try
            {
                var positionCheck = await _db.Positions.FirstOrDefaultAsync(v => v.Title == position.Title);
                if (positionCheck != null)
                {
                    return (false, "Position already exists");
                }
                else
                {
                    Position newPosition = new Position { Title = position.Title };

                    await _db.Positions.AddAsync(newPosition);
                    await _db.SaveChangesAsync();
                    return (true, "Position Successfully added");
                }
            }
            catch (Exception ex)
            {

                return (false, ex.Message);
            }
        }

        public async Task<(bool, Position)> GetPositionById(int id)
        {
            try
            {
                Position data = await _db.Positions.FirstOrDefaultAsync(v => v.Id == id);
                if (data != null)
                {
                    return (true, data);
                }
                
                return (false, new Position());
            }
            catch (Exception ex)
            {
                return (false, new Position());
            }
        }
    }
}
