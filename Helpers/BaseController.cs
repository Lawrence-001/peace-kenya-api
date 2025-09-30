using Microsoft.AspNetCore.Mvc;
using peace_kenya_api.Helpers;

namespace peace_kenya_api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult HandleResult<T>(Result<T> result)
        {
            switch (result.Status)
            {
                case ResultStatus.Success:
                    {
                        return Ok(result.Data);
                    }

                case ResultStatus.NotFound:
                    {
                        return NotFound(result.Error);
                    }

                case ResultStatus.ValidationError:
                    {
                        return BadRequest(result.Error);
                    }

                case ResultStatus.Failure:
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, result.Error);
                    }

                default:
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected error");
                    }
            }
        }
    }
}
