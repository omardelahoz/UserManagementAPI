using MediatR;
using UserManagement.Application.Responses;
using UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Users.Commands.Update
{
    public class UpdateUser : IRequest<Response<User>>
    {
        public User? User { get; set; }

        public UpdateUser(User user)
        {
            User = user;
        }
    }
}
