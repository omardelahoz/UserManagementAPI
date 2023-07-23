using MediatR;
using UserManagement.Application.Responses;
using UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Users.Commands.Create
{
    public class CreateUser : IRequest<Response<User>>
    {
        public User? User { get; set; }

        public CreateUser(User user)
        {
            User = user;
        }
    }
}
