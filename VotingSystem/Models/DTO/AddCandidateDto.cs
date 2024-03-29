﻿using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Models.DTO
{
    public class AddCandidateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string SSN { get; set; }
        [Required]
        public int PositionId { get; set; }
    }
}
