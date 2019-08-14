using AutoMapper;
using GraphQL.Domain.Perfil;
using GraphQL.Domain.Usuario;

namespace GraphQL.Infrastructure.PostgresDataAccess.AutoMapperProfile
{
    public class InfraDomainProfile : Profile
    {
        public InfraDomainProfile()
        {
            CreateMap<Entities.Usuario, Usuario>();
            CreateMap<Usuario, Entities.Usuario>();

            CreateMap<Entities.Perfil, Perfil>();
            CreateMap<Perfil, Entities.Perfil>();
        }
    }
}
