using AutoMapper;
using UserManagement.Application.Utilities;
using DTO = UserManagement.Domain.DTO;
using Entity = UserManagement.Domain.Entities;

namespace UserManagement.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DTO.User, Entity.User>()
                .ForMember(o => o.Password, s => s.MapFrom(m => EncryptionDecryptionManager.Encrypt(m.Password)));
            CreateMap<Entity.User, DTO.User>();
            CreateMap<Entity.Role, DTO.Role>().ReverseMap();
            CreateMap<Entity.UsersRole, DTO.UsersRole>().ReverseMap();
        }
    }
}
