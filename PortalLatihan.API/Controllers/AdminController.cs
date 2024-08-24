using Microsoft.AspNetCore.Mvc;
using PortalLatihan.Application.Services.Interface;

namespace PortalLatihan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IInitialDataService initialDataService) : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("InitialData")]
        public async Task<IActionResult> InitialData()
        {
            try
            {
                await initialDataService.InitializeZoneRegionData();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
