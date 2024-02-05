using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Models.DTO;
using VotingSystem.Services;
using VotingSystem.Services.IServices;

namespace VotingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        protected ResponseDto _responseDto;
        public PositionController(IPositionService positionService)
        {
                _responseDto = new ResponseDto();
            _positionService = positionService;
        }

        [HttpPost("AddPosition")]
        public async Task<IActionResult> AddPosition([FromBody] AddPositionDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(data);
            }
            var result = await _positionService.AddPosition(data);
            _responseDto.IsSuccess = result.Item1;
            _responseDto.Message = result.Item2;
            return Ok(_responseDto);
        }
    }
}
