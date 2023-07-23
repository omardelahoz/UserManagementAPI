using MediatR;
using UserManagement.Application.Responses;
using UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Users.Commands.Disable
{
    public class DisableUser : IRequest<Response<User>>
    {
        public Guid Id { get; set; }

        public DisableUser(Guid id)
        {
            Id = id;
        }
    }
}
