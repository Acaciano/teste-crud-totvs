using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using Cbyk.ATS.API.Extension;

namespace Cbyk.ATS.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        public ApiBaseController()
        {
        }

        protected new IActionResult Response<T>(ApiResponse<T> result)
        {
            if (result != null && result.Success) return Ok(result);

            return BadRequest(result);
        }

        protected IActionResult ResponseError(List<string> errors)
        {
            return BadRequest(ApiResponseExtension.ResultError(string.Empty, errors));
        }

        protected IActionResult ResponseError(string error)
        {
            return BadRequest(ApiResponseExtension.ResultError(string.Empty, error));
        }

        protected IActionResult ResponseError(ModelStateDictionary dictionary)
        {
            return BadRequest(ApiResponseExtension.ResultError(string.Empty, dictionary));
        }
    }
}
