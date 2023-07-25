using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.Application.Features.Users.Queries.Filters.Login;
using DTO = UserManagement.Domain.DTO;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string? _secretKey;

        public LoginController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;
            _secretKey = config.GetSection("Jwt").GetSection("Key").Value;
        }

        [HttpPost]
        public async Task<ActionResult> Login()
        {
            var query = new GetUsetByLogin(new DTO.Login());
            var result = await _mediator.Send(query);

            if (result.Result)
            {
                result.ResultObject!.Token = TokenGenerate(result.ResultObject);

                return Ok(result);
            }
            return Unauthorized();
            
        }

        private string TokenGenerate(DTO.Login? login)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey!);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, login!.User!.Name),
                new Claim(ClaimTypes.Email, login!.User!.Email)
            };
            foreach (var rol in login.User.UsersRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol.Role.RolName));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
