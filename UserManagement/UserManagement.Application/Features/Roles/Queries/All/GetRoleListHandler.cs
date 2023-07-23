using AutoMapper;
using MediatR;
using UserManagement.Application.Contracts.Database;
using UserManagement.Application.Responses;
using UserManagement.Application.Utilities;
using DTO = UserManagement.Domain.DTO;
using Entity = UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Roles.Queries.All
{
    public class GetRoleListHandler : IRequestHandler<GetRoleList, Response<DTO.Role>>
    {
        private readonly IGenericRepository<Entity.Role> _genericRepository;
        private readonly IMapper _mapper;

        public GetRoleListHandler(IGenericRepository<Entity.Role> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Response<DTO.Role>> Handle(GetRoleList request, CancellationToken cancellationToken)
        {

            Response<DTO.Role> result = new Response<DTO.Role>()
            {
                Total = await _genericRepository.GetTotal(),
                ResultList = _mapper.Map<List<DTO.Role>>(await _genericRepository.GetAll(x => x.OrderBy(y => y.RolName)))
            };

            return result;
        }
    }
}
