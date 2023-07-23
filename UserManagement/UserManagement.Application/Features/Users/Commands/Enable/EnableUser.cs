using MediatR;
using UserManagement.Application.Responses;
using UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Users.Commands.Enable
{
    public class EnableUser : IRequest<Response<User>>
    {
        public Guid Id { get; set; }

        public EnableUser(Guid id)
        {
            Id = id;
        }
    }
}
