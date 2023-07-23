using AutoMapper;
using FluentValidation;
using MediatR;
using UserManagement.Application.Contracts.Database;
using UserManagement.Application.Responses;
using UserManagement.Application.Validators;
using DTO = UserManagement.Domain.DTO;
using Entity = UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Users.Commands.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, Response<DTO.User>>
    {
        private readonly IGenericRepository<Entity.User> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Entity.User> _validator;

        public UpdateUserHandler(IGenericRepository<Entity.User> genericRepository, IMapper mapper, IValidator<Entity.User> validator)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Response<DTO.User>> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var instance = _mapper.Map<Entity.User>(request.User);

            ((UsersValidator)_validator).Evaluate(instance);

            Response<DTO.User> result = new Response<DTO.User>();
            result.ResultObject = _mapper.Map<DTO.User>(await _genericRepository.Update(instance));

            return result;
        }
    }
}
