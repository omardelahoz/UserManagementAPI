using MediatR;
using UserManagement.Application.Responses;
using UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Users.Commands.Delete
{
    public class DeleteUser : IRequest<Response<User>>
    {
        public Guid Id { get; set; }
        public DeleteUser(Guid id)
        {
            Id = id;
        }
    }
}
