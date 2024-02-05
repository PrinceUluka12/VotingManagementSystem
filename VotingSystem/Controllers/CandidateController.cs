using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Models.DTO;
using VotingSystem.Services.IServices;

namespace VotingSystem.Controllers
{
    [Route("api/Candidate")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        protected ResponseDto _responseDto;
        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
            _responseDto = new ResponseDto();
        }

        [HttpPost("RegisterCandidate")]
        public async Task<IActionResult> RegisterCandidate([FromBody] AddCandidateDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(data);
            }
            var result = await _candidateService.AddCandidate(data);
            _responseDto.IsSuccess = result.Item1;
            _responseDto.Message = result.Item2;
            return Ok(_responseDto);
        }

        [HttpGet("GetCandidateById/{id:int}")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            var result = await _candidateService.GetCandidateById(id);
            _responseDto.IsSuccess = result.Item1;
            _responseDto.Result = result.Item2;
            if (result.Item1)
            {
                _responseDto.Message = "Successful";
            }
            else
            {
                _responseDto.Message = "Unsuccessful";
            }
            return Ok(_responseDto);
        }


       
    }
}
