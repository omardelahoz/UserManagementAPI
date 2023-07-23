using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Users.Queries.Filters.Login;
using DTO = UserManagement.Domain.DTO;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Login()
        {
            var query = new GetUsetByLogin(new DTO.Login());
            var result = await _mediator.Send(query);

            if (result.Result)
            {

            }

            return Ok(result);
        }
    }
}
