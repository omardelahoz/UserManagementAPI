using AutoMapper;
using MediatR;
using UserManagement.Application.Contracts.Database;
using UserManagement.Application.Responses;
using UserManagement.Application.Utilities;
using DTO = UserManagement.Domain.DTO;
using Entity = UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Users.Queries.All
{
    public class GetUserListHandler : IRequestHandler<GetUserList, Response<DTO.User>>
    {
        private readonly IGenericRepository<Entity.User> _genericRepository;
        private readonly IMapper _mapper;

        public GetUserListHandler(IGenericRepository<Entity.User> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Response<DTO.User>> Handle(GetUserList request, CancellationToken cancellationToken)
        {
            var paginate = request.paginate;
            var orderBy = OrderByUserList.GetOrderBy(paginate!);

            var list = await _genericRepository.GetAll(orderBy, paginate);
            var total = await _genericRepository.GetTotal();
            Response<DTO.User> result = new Response<DTO.User>()
            {
                Total = total,
                ResultList = _mapper.Map<List<DTO.User>>(list)
            };

            return result;
        }
    }
}
