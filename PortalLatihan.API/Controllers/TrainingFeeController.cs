using Microsoft.AspNetCore.Mvc;
using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;

namespace PortalLatihan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingFeeController(ITrainingFeeService trainingFeeService, IStaffService staffService) : Controller
    {

        [HttpGet("ListByTrainingID/{trainingID}")]
        public async Task<IActionResult> GetListByTrainingID(Guid trainingID)
        {
            try
            {
                #region Auth
                var httpRequest = HttpContext.Request;
                string token = "";
                string email = "";

                if (httpRequest.Headers.TryGetValue("X-Login-Token", out var authHeaderValue))
                {
                    token = authHeaderValue.ToString();
                    var tokenData = staffService.CheckToken(token);
                    email = tokenData.Email;
                    if (tokenData == null) return Unauthorized();
                }
                else
                {
                    return Unauthorized();
                }
                #endregion

                var result = await trainingFeeService.GetListByTrainingID(trainingID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListByTrainingIDAvailable/{trainingID}")]
        public async Task<IActionResult> GetListByTrainingIDAvailable(Guid trainingID)
        {
            try
            {
                var result = await trainingFeeService.GetListByTrainingID(trainingID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
