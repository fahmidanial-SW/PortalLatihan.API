using Microsoft.AspNetCore.Mvc;
using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;
using PortalLatihan.Domain.Entities;
using System;

namespace PortalLatihan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController(IParticipantService participantService, IStaffService staffService) : ControllerBase
    {
        [HttpGet("ByTrainingID/{trainingID}")]
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

                var result = await participantService.GetListByTrainingID(trainingID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ByParticipantID/{ID}")]
        public async Task<IActionResult> Update([FromBody] ParticipantUpdateRequest participantUpdateInput)
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

                participantUpdateInput.Validate();
                await participantService.Update(participantUpdateInput, email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateAttendance")]
        public async Task<IActionResult> UpdateAttendance([FromBody] ParticipantUpdateAttendanceRequest participantUpdateAttendanceInput)
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

                participantUpdateAttendanceInput.Validate();
                await participantService.UpdateAttendance(participantUpdateAttendanceInput, email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("ByParticipantID/{ID}")]
        //public async Task<IActionResult> GetParticipantByParticipantID(Guid ID)
        //{
        //    try
        //    {
        //        #region Auth
        //        var httpRequest = HttpContext.Request;
        //        string token = "";
        //        string email = "";

        //        if (httpRequest.Headers.TryGetValue("X-Login-Token", out var authHeaderValue))
        //        {
        //            token = authHeaderValue.ToString();
        //            var tokenData = staffService.CheckToken(token);
        //            email = tokenData.Email;
        //            if (tokenData == null) return Unauthorized();
        //        }
        //        else
        //        {
        //            return Unauthorized();
        //        }
        //        #endregion

        //        var result = await participantService.GetParticipantByParticipantID(ID);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
