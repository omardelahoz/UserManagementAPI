﻿using AutoMapper;
using FluentValidation;
using MediatR;
using UserManagement.Application.Contracts.Database;
using UserManagement.Application.Responses;
using UserManagement.Application.Validators;
using DTO = UserManagement.Domain.DTO;
using Entity = UserManagement.Domain.Entities;

namespace UserManagement.Application.Features.Roles.Commands.Create
{
    public class CreateRoleHandler : IRequestHandler<CreateRole, Response<DTO.Role>>
    {
        private readonly IGenericRepository<Entity.Role> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Entity.Role> _validator;

        public CreateRoleHandler(IGenericRepository<Entity.Role> genericRepository, IMapper mapper, IValidator<Entity.Role> validator)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Response<DTO.Role>> Handle(CreateRole request, CancellationToken cancellationToken)
        {
            var instance = _mapper.Map<Entity.Role>(request.Role);

            ((RolesValidator)_validator).Evaluate(instance);

            Response<DTO.Role> result = new Response<DTO.Role>();
            result.ResultObject = _mapper.Map<DTO.Role>(await _genericRepository.Add(instance));

            return result;

        }
    }
}
