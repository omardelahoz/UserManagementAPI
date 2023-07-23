using MediatR;
using UserManagement.Application.Contracts.Database;
using UserManagement.Application.Responses;
using UserManagement.Domain.Entities;
using DTO = UserManagement.Domain.DTO;
using Entity = UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Roles.Commands.Delete
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRole, Response<DTO.Role>>
    {
        private readonly IGenericRepository<Role> _genericRepository;

        public DeleteRoleHandler(IGenericRepository<Role> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Response<DTO.Role>> Handle(DeleteRole request, CancellationToken cancellationToken)
        {
            return new Response<DTO.Role>()
            {
                Result = await _genericRepository.Delete(request.Id)
            };
        }
    }
}
