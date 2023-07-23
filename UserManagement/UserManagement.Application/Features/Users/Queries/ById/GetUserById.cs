using MediatR;
using UserManagement.Domain.DTO;

using UserManagement.Application.Responses;

namespace UserManagement.Application.Features.Users.Queries.ById
{
    public class GetUserById : IRequest<Response<User>>
    {
        public Guid Id { get; set; }

        public GetUserById(Guid id)
        {
            Id = id;
        }
    }
}
