using MediatR;
using UserManagement.Application.Responses;
using UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Users.Queries.All
{
    public class GetUserList : IRequest<Response<User>>
    {
        public Paginate? paginate { get; }

        public GetUserList(string? orderBy, bool ascendent, int? pageIndex, int? pageSize)
        {
            paginate = new Paginate();

            paginate.OrderBy = orderBy ?? "default";
            paginate.Ascendent = ascendent;

            if(pageIndex.HasValue) paginate.PageIndex = pageIndex.Value;
            if(pageSize.HasValue) paginate.PageSize = pageSize.Value;
        }
    }
}
