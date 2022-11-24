using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MindBetter.API.Dtos;
using MindBetter.Core.Model;
using MindBetter.Infrastructure.Data.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MindBetter.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IConfiguration configuration,
            IUserRepository userRepository)
        {
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));

            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<string>> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            User user = await _userRepository.ValidateUserCredentials(
                authenticationRequestBody.userName,
                Encoding.ASCII.GetBytes(string.Empty),
                Encoding.ASCII.GetBytes(string.Empty));

            if (user is null)
            {
                return Unauthorized();
            }

            // create token
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString())
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
    }
}
