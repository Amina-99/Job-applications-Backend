using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SofthouseTask.Constants;
using SofthouseTask.Interfaces;
using SofthouseTask.Models.Request;
using System;
using System.Threading.Tasks;

namespace SofthouseTask.Controllers
{
    [Route("api/job-application")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly ILogger<JobApplicationController> _logger;

        public JobApplicationController(IJobApplicationService jobApplicationService, ILogger<JobApplicationController> logger)
        {
            _jobApplicationService = jobApplicationService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("apply")]
        public async Task<IActionResult> AddApplicationAsync([FromForm] JobApplicationDTO payload)
        {
            try
            {
                var result = await _jobApplicationService.AddApplicationAsync(payload);
                if (result)
                    return StatusCode(StatusCodes.Status201Created);
                else return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("cv/{id}")]
        public async Task<IActionResult> GetAplicationCvAsync(int id)
        {
            try
            {
                var result = await _jobApplicationService.GetApplicationCvAsync(id);
                return File(result, "APPLICATION/octet-stream");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> GetApplications()
        {
            try
            {
                var result = await _jobApplicationService.GetApplicationsAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            try
            {
                var result = await _jobApplicationService.DeleteApplicationById(id);
                if (!result)
                {
                    return BadRequest(ErrorMessages.DeleteFail);
                }
                return NoContent();

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }


    }
}
