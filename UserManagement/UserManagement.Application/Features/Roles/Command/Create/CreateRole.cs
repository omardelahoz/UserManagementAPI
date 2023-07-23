using MediatR;
using UserManagement.Application.Responses;
using UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Roles.Commands.Create
{
    public class CreateRole : IRequest<Response<Role>>
    {
        public Role? Role { get; set; }

        public CreateRole(Role role)
        {
            Role = role;
        }
    }
}
