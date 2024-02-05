using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Models.DTO
{
    public class AddVoterDto
    {
        [Required]
        public string SSN { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
    }
}
