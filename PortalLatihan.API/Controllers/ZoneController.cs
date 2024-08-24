using Microsoft.AspNetCore.Mvc;
using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;

namespace PortalLatihan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController(IRefZoneService refZoneService, IStaffService staffService) : ControllerBase
    {
        [HttpGet("Dropdown")]
        public async Task<ActionResult<List<ZoneDropdownResponse>>> Dropdown()
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

                var result = await refZoneService.GetDropdownList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
