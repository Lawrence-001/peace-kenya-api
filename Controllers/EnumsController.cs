using Microsoft.AspNetCore.Mvc;
using peace_kenya_api.Services.Interfaces;

namespace peace_kenya_api.Controllers
{
    [Route("api/enums")]
    [ApiController]
    public class EnumsController : ControllerBase
    {
        private readonly IEnumService _enumService;

        public EnumsController(IEnumService enumService)
        {
            _enumService = enumService;
        }

        [HttpGet("all-enums")]
        public async Task<IActionResult> GetAllEnums()
        {
            var result = await _enumService.GetAllEnums();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        //[HttpGet("{enumName}")]
        //public async Task<IActionResult> GetEnumByName(string enumName)
        //{
        //    var result = await _enumService.GetEnumByName(enumName);
        //    if (!result.IsSuccess)
        //        return NotFound(result);

        //    return Ok(result);
        //}


    }
}
