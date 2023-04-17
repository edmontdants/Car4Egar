using Car4EgarAPI.Models.Context;
using Car4EgarAPI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Car4EgarAPI.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {

            private readonly Car4EgarContext db;
            private readonly UserManager<SystemUser> _userManager;
            private readonly SignInManager<SystemUser> _signInManager;
            private readonly IConfiguration _configuration;

            public AuthController(UserManager<SystemUser> userManager, SignInManager<SystemUser> signInManager, IConfiguration configuration, Car4EgarContext dataContext)
            {
                db = dataContext;
                _userManager = userManager;
                _signInManager = signInManager;
                _configuration = configuration;
            }

            [HttpPost("loginEslam")]
            public async Task<IActionResult> Login(LoginDto loginDto)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);

                if (user == null)
                {
                    return Unauthorized();
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

                if (!result.Succeeded)
                {
                    return Unauthorized();
                }

                var token = GenerateJwtToken(user);

                return Ok(new { token });
            }

            [HttpPost("registerEslam")]
            public async Task<IActionResult> Register(RegisterDto registerDto)
            {
                var user = new SystemUser
                {
                    UserName = registerDto.Name,
                    Email = registerDto.Email,
                    NID = registerDto.NID
                };
                db.Add(user);
                var result = await _userManager.CreateAsync(user, registerDto.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return Ok();
            }

            [Authorize]
            [HttpGet("protected")]
            public IActionResult Protected()
            {
                return Ok("This is a protected endpoint.");
            }

            private string GenerateJwtToken(SystemUser user)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, user.NID),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }
    }