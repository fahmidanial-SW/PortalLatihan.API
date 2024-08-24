using Microsoft.AspNetCore.Mvc;
using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;

namespace PortalLatihan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController(IStaffService staffService) : ControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] StaffAddRequest staffAddRequest)
        {
            try
            {
                await staffService.Add(staffAddRequest,"");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody] StaffLoginRequest staffLoginRequest)
        {
            try
            {
                string token = await staffService.GetUserToken(staffLoginRequest);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetRole")]
        public ActionResult<string> GetRole()
        {
            try
            {
                #region Auth
                var httpRequest = HttpContext.Request;
                string token = "";
                string email = "";
                string role = "";

                if (httpRequest.Headers.TryGetValue("X-Login-Token", out var authHeaderValue))
                {
                    token = authHeaderValue.ToString();
                    var tokenData = staffService.CheckToken(token);
                    email = tokenData.Email;
                    role = tokenData.Role;
                    if (tokenData == null) return Unauthorized();
                }
                else
                {
                    return Unauthorized();
                }
                #endregion

                return role;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
