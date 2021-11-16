using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SofthouseTask.Data.Context;
using SofthouseTask.Interfaces;
using SofthouseTask.Models.Request;
using SofthouseTask.Models.Response;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SofthouseTask.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<JobApplicationService> _logger;
        private readonly ITokenService _tokenService;

        public AuthService(AppDbContext context, ILogger<JobApplicationService> logger, ITokenService tokenService)
        {
            _context = context;
            _logger = logger;
            _tokenService = tokenService;
        }
        public async Task<UserDTO> LoginAsync(LoginDTO loginDTO)
        {
            try
            {
                var user = await _context.User.SingleOrDefaultAsync(u => u.UserName == loginDTO.Username);
                if (user == null) return null;
                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
              
                for(int i=0; i<computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i]) return null;
                }

                return new UserDTO
                {
                    Username = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

     
    }
}
