using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Roles.Queries.All;
using UserManagement.Application.Features.Roles.Queries.ById;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        { 
            return Ok(await _mediator.Send(new GetRoleList()));
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetRoleById(id)));
        }
    }
}
