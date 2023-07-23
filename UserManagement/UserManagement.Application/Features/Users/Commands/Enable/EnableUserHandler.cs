using MediatR;
using UserManagement.Application.Contracts.Database;
using UserManagement.Application.Responses;
using DTO = UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Users.Commands.Enable
{
    public class EnableUserHandler : IRequestHandler<EnableUser, Response<DTO.User>>
    {
        private readonly IUserRepository _userRepository;

        public EnableUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response<DTO.User>> Handle(EnableUser request, CancellationToken cancellationToken)
        {
            return new Response<DTO.User>()
            {
                Result = await _userRepository.EnableUser(request.Id)
            };
        }
    }
}
