using MediatR;
using UserManagement.Application.Responses;
using UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Roles.Queries.All
{
    public class GetRoleList : IRequest<Response<Role>>
    {
        public GetRoleList()
        {
            
        }
    }
}
