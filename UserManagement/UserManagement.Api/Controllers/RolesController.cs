using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Roles.Commands.Create;
using UserManagement.Application.Features.Roles.Commands.Delete;
using UserManagement.Application.Features.Roles.Commands.Update;
using UserManagement.Application.Features.Roles.Queries.All;
using UserManagement.Application.Features.Roles.Queries.ById;
using UserManagement.Application.Features.Users.Queries.All;
using UserManagement.Application.Features.Users.Queries.ById;
using UserManagement.Domain.DTO;

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
        public async Task<ActionResult> Get(string? orderBy, bool ascendent, int pageIndex, int pageSize)
        { 
            return Ok(await _mediator.Send(new GetRoleList(orderBy, ascendent, pageIndex, pageSize)));
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetRoleById(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Save(Role role)
        {
            return Ok(await _mediator.Send(new CreateRole(role)));
        }

        [HttpPut]
        public async Task<ActionResult> Update(Role role)
        {
            return Ok(await _mediator.Send(new UpdateRole(role)));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteRole(id)));
        }
    }
}
