using Microsoft.AspNetCore.Mvc;
using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;

namespace PortalLatihan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController(ITrainingService trainingService, IStaffService staffService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<TrainingListResponse>> GetList()
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

                var result = await trainingService.GetList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetListByStatus/{status}")]
        public async Task<ActionResult<TrainingListResponse>> GetListByStatus(string status)
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

                var result = await trainingService.GetListByStatus(status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetListByUser")]
        public async Task<ActionResult<TrainingListResponse>> GetListByUser()
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

                var result = await trainingService.GetListByUser(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetListAvailable")]
        public async Task<ActionResult<TrainingListResponse>> GetListAvailable()
        {
            try
            {
                var result = await trainingService.GetListAvailable();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(TrainingAddRequest trainingInsertInput)
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

                trainingInsertInput.Validate();
                await trainingService.Add(trainingInsertInput, email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(TrainingUpdateRequest trainingUpdateInput)
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

                trainingUpdateInput.Validate();
                await trainingService.Update(trainingUpdateInput, email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
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

                await trainingService.Delete(id, email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDetailResponse>> GetDetail(Guid id)
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

                var result = await trainingService.GetDetail(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDetailAvailable/{id}")]
        public async Task<ActionResult<TrainingDetailResponse>> GetDetailAvailable(Guid id)
        {
            try
            {
                var result = await trainingService.GetDetail(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Approve")]
        public async Task<IActionResult> Approve(TrainingApproveRequest trainingApproveRequest)
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

                await trainingService.Approve(trainingApproveRequest.TrainingID, trainingApproveRequest.Remark??"", email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Reject")]
        public async Task<IActionResult> Reject(TrainingRejectRequest trainingRejectRequest)
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

                await trainingService.Reject(trainingRejectRequest.TrainingID, trainingRejectRequest.Remark??"", email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
