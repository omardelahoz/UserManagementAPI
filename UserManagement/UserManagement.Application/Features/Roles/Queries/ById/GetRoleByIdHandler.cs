using MediatR;
using Entity = UserManagement.Domain.Entities;
using DTO = UserManagement.Domain.DTO;
using UserManagement.Application.Responses;
using AutoMapper;
using UserManagement.Application.Contracts.Database;

namespace UserManagement.Application.Features.Roles.Queries.ById
{
    public class GetRoleByIdHandler : IRequestHandler<GetRoleById, Response<DTO.Role>>
    {
        private readonly IGenericRepository<Entity.Role> _genericRepository;
        private readonly IMapper _mapper;

        public GetRoleByIdHandler(IGenericRepository<Entity.Role> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Response<DTO.Role>> Handle(GetRoleById request, CancellationToken cancellationToken)
        {
            Response<DTO.Role> result = new Response<DTO.Role>()
            {
                ResultObject = _mapper.Map<DTO.Role>(await _genericRepository.GetById(request.Id))
            };

            return result;
        }
    }
}
