using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Retailmize.API.Models;
using Retailmize.Domain.Account;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Retailmize.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;
        public TokenController(IAuthenticate authentication, IConfiguration configuration)
        {
            _configuration = configuration;
            _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel model)
        {
            var result = await _authentication.Authenticate(model.Email, model.Password);
            if (result)
                return GenerateToken(model);
            else
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return BadRequest(ModelState);
        }

        [HttpPost("Register")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _authentication.Register(model.Email, model.Password);

            if (result)
                return Ok(result);
            else
                ModelState.AddModelError(string.Empty, "Invalid registration attempt");
            return BadRequest(ModelState);
        }

        private UserToken GenerateToken(LoginModel model)
        {
            var claims = new[]
            {
                new Claim("email", model.Email),
                new Claim("value", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var expireIn = DateTime.UtcNow.AddMinutes(10);
            JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: claims,
                    expires: expireIn,
                    signingCredentials: credentials
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expireIn
            };
        }
    }
}
