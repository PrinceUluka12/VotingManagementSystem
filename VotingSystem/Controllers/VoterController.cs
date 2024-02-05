using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Models.DTO;
using VotingSystem.Services;
using VotingSystem.Services.IServices;

namespace VotingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoterController : ControllerBase
    {
        private readonly IVoterService _voterService;
        protected ResponseDto _responseDto;
        public VoterController(IVoterService voterService)
        {
            _responseDto = new ResponseDto();
            _voterService = voterService;
        }
        [HttpPost("RegisterVoter")]
        public async Task<IActionResult> RegisterCandidate([FromBody] AddVoterDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(data);
            }
            var result = await _voterService.AddVoter(data);
            _responseDto.IsSuccess = result.Item1;
            _responseDto.Message = result.Item2;
            return Ok(_responseDto);
        }

        [HttpGet("GetVoterById/{id:int}")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            var result = await _voterService.GetVoterById(id);
            _responseDto.IsSuccess = result.Item1;
            _responseDto.Result = result.Item2;
            if (result.Item1)
            {
                _responseDto.Message = "Successful";
            }
            
            return Ok(_responseDto);
        }
        [HttpGet("GetAllVoters")]
        public async Task<IActionResult> GetAllVoters()
        {
            var result = await _voterService.GetAllVoters();
            _responseDto.IsSuccess = result.Item1;
            _responseDto.Result = result.Item2;
            if (result.Item1)
            {
                _responseDto.Message = "Successful";
            }
            return Ok(_responseDto);
        }
    }
}
