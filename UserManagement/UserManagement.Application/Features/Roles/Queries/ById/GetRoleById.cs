using MediatR;
using UserManagement.Domain.DTO;

using UserManagement.Application.Responses;

namespace UserManagement.Application.Features.Roles.Queries.ById
{
    public class GetRoleById : IRequest<Response<Role>>
    {
        public Guid Id { get; set; }

        public GetRoleById(Guid id)
        {
            Id = id;
        }
    }
}
