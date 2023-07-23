using MediatR;
using UserManagement.Application.Contracts.Database;
using UserManagement.Application.Responses;
using UserManagement.Domain.Entities;
using DTO = UserManagement.Domain.DTO;
using Entity = UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Users.Commands.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser, Response<DTO.User>>
    {
        private readonly IGenericRepository<Entity.User> _genericRepository;

        public DeleteUserHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Response<DTO.User>> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            return new Response<DTO.User>()
            {
                Result = await _genericRepository.Delete(request.Id)
            };
        }
    }
}
