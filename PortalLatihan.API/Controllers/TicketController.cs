using Microsoft.AspNetCore.Mvc;
using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;
using PortalLatihan.Domain.Entities;

namespace PortalLatihan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController(ITicketService ticketService, IStaffService staffService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
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

                var result = await ticketService.GetList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByTrainingID/{trainingID}")]
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

                var result = await ticketService.GetListByTrainingID(trainingID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(TicketAddRequest ticketInsertInput)
        {
            try
            {
                ticketInsertInput.Validate();
                await ticketService.Add(ticketInsertInput, "public");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{ticketID}/Paid")]
        public async Task<IActionResult> Paid(Guid ticketID)
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

                await ticketService.Paid(ticketID, email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{ticketID}/Cancel")]
        public async Task<IActionResult> Cancel(Guid ticketID)
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

                await ticketService.Cancel(ticketID, email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(Guid id)
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

                var result = await ticketService.GetDetail(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CalculatePrice")]
        public async Task<IActionResult> CalculatePrice(TicketPriceRequest ticketPriceRequest)
        {
            try
            {
                var result = await ticketService.CalculatePrice(ticketPriceRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
