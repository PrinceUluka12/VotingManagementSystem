using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Models.DTO
{
    public class AddPositionDto
    {
        [Required]
        public string Title { get; set; }
    }
}
