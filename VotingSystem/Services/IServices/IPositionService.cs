using VotingSystem.Models;
using VotingSystem.Models.DTO;

namespace VotingSystem.Services.IServices
{
    public interface IPositionService
    {
        Task<(bool,string)>AddPosition(AddPositionDto position);
        Task<(bool,Position)> GetPositionById(int id);
    }
}
