using MediatR;
using UserManagement.Application.Responses;
using UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Roles.Commands.Delete
{
    public class DeleteRole : IRequest<Response<Role>>
    {
        public Guid Id { get; set; }
        public DeleteRole(Guid id)
        {
            Id = id;
        }
    }
}
