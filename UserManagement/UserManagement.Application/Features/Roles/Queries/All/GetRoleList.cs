using MediatR;
using UserManagement.Application.Responses;
using UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Roles.Queries.All
{
    public class GetRoleList : IRequest<Response<Role>>
    {
        public Paginate? paginate { get; }

        public GetRoleList(string? orderBy, bool ascendent, int? pageIndex, int? pageSize)
        {
            paginate = new Paginate();

            paginate.OrderBy = orderBy ?? "default";
            paginate.Ascendent = ascendent;

            if(pageIndex.HasValue) paginate.PageIndex = pageIndex.Value;
            if(pageSize.HasValue) paginate.PageSize = pageSize.Value;
        }
    }
}
