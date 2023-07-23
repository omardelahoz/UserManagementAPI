using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Features.Users.Commands.Create;
using UserManagement.Application.Features.Users.Commands.Delete;
using UserManagement.Application.Features.Users.Commands.Disable;
using UserManagement.Application.Features.Users.Commands.Enable;
using UserManagement.Application.Features.Users.Commands.Update;
using UserManagement.Application.Features.Users.Queries.All;
using UserManagement.Application.Features.Users.Queries.ById;
using DTO = UserManagement.Domain.DTO;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string? orderBy, bool ascendent, int pageIndex, int pageSize)
        {
            return Ok(await _mediator.Send(new GetUserList(orderBy, ascendent, pageIndex, pageSize)));
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetUserById(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Save(DTO.User user)
        {
            return Ok(await _mediator.Send(new CreateUser(user)));
        }

        [HttpPut]
        public async Task<ActionResult> Update(DTO.User user)
        {
            return Ok(await _mediator.Send(new UpdateUser(user)));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteUser(id)));
        }

        [HttpPost]
        [Route("Disable")]
        public async Task<ActionResult> Disable(Guid Id)
        {
            return Ok(await _mediator.Send(new DisableUser(Id)));
        }

        [HttpPost]
        [Route("Enable")]
        public async Task<ActionResult> Enable(Guid Id)
        {
            return Ok(await _mediator.Send(new EnableUser(Id)));
        }
    }
}
