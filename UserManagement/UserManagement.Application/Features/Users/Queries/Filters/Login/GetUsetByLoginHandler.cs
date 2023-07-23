using AutoMapper;
using FluentValidation;
using MediatR;
using UserManagement.Application.Contracts.Database;
using UserManagement.Application.Exceptions;
using UserManagement.Application.Responses;
using UserManagement.Application.Utilities;
using UserManagement.Application.Validators;
using DTO = UserManagement.Domain.DTO;
using Entity = UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Users.Queries.Filters.Login
{
    public class GetUsetByLoginHandler : IRequestHandler<GetUsetByLogin, Response<DTO.Login>>
    {
        private readonly IGenericRepository<Entity.User> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<DTO.Login> _validator;

        public GetUsetByLoginHandler(IGenericRepository<Entity.User> eventRepository, IMapper mapper, IValidator<DTO.Login> validator)
        {
            _genericRepository = eventRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Response<DTO.Login>> Handle(GetUsetByLogin request, CancellationToken cancellationToken)
        {
            ((LoginValidator)_validator)
                .Evaluate(request.Login);


            var user = await _genericRepository.Get(
                    u => u.Password == EncryptionDecryptionManager.Encrypt(request.Login.Password) && u.Email.ToLower() == request.Login.Username.ToLower()
            );

            if(user == null || !user.Any())
            {
                throw new UserManagementException("No se encontró información con los datos suministrados");
            }

            

            Response<DTO.Login> result = new Response<DTO.Login>();
            DTO.Login loginObj = new DTO.Login();
            loginObj.User = _mapper.Map<DTO.User>(user.FirstOrDefault());
            result.ResultObject = loginObj;
            return result;
        }
    }
}
