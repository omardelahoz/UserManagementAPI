using MediatR;
using Entity = UserManagement.Domain.Entities;
using DTO = UserManagement.Domain.DTO;
using UserManagement.Application.Responses;
using AutoMapper;
using UserManagement.Application.Contracts.Database;

namespace UserManagement.Application.Features.Users.Queries.ById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserById, Response<DTO.User>>
    {
        private readonly IGenericRepository<Entity.User> _genericRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IGenericRepository<Entity.User> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Response<DTO.User>> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            Response<DTO.User> result = new Response<DTO.User>()
            {
                ResultObject = _mapper.Map<DTO.User>(await _genericRepository.GetById(request.Id))
            };

            return result;
        }
    }
}
