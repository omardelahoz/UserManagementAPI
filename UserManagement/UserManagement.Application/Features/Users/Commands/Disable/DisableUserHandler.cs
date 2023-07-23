using MediatR;
using UserManagement.Application.Contracts.Database;
using UserManagement.Application.Responses;
using DTO = UserManagement.Domain.DTO;

namespace UserManagement.Application.Features.Users.Commands.Disable
{
    public class DisableUserHandler : IRequestHandler<DisableUser, Response<DTO.User>>
    {
        private readonly IUserRepository _userRepository;

        public DisableUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response<DTO.User>> Handle(DisableUser request, CancellationToken cancellationToken)
        {
            return new Response<DTO.User>()
            {
                Result = await _userRepository.DisableUser(request.Id)
            };
        }
    }
}
