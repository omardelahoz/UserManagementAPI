using MediatR;
using UserManagement.Application.Responses;
using UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Roles.Commands.Update
{
    public class UpdateRole : IRequest<Response<Role>>
    {
        public Role? Role { get; set; }

        public UpdateRole(Role role)
        {
            Role = role;
        }
    }
}
