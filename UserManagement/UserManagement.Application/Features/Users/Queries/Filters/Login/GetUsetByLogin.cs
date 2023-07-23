using MediatR;
using UserManagement.Application.Responses;
using DTO = UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Users.Queries.Filters.Login
{
    public class GetUsetByLogin : IRequest<Response<DTO.Login>>
    {
        public DTO.Login Login { get; set; }
        public GetUsetByLogin(DTO.Login login) 
        {
            Login = login;
        }
    }
}
