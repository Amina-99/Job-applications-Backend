using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SofthouseTask.Constants;
using SofthouseTask.Interfaces;
using SofthouseTask.Models.Request;
using System;
using System.Threading.Tasks;

namespace SofthouseTask.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _loginService;
        private readonly ILogger<JobApplicationController> _logger;

        public AuthController(IAuthService loginService,ILogger<JobApplicationController> logger)
        {
            _loginService = loginService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO loginDTO)
        {
            try
            {
                var user = await _loginService.LoginAsync(loginDTO);
                if(user == null)
                {
                    return BadRequest(ErrorMessages.InvalidCredentials);
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

    }
}
