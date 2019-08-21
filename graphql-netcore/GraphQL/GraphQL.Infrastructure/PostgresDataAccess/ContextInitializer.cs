using GraphQL.Domain.Usuario;
using GraphQL.Infrastructure.PostgresDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphQL.Infrastructure.PostgresDataAccess
{
    public static class ContextInitializer
    {
        public static void Seed(Context context)
        {
            if (!context.Usuario.Any())
            {
                context.Usuario.AddRange(GetUsuario(GetPerfis()));
                context.SaveChanges();
            }
        }

        static List<Domain.Perfil.Perfil> GetPerfis()
        {
            return new List<Domain.Perfil.Perfil>()
            {
                new Domain.Perfil.Perfil(Guid.NewGuid(), "Administrador"),
                new Domain.Perfil.Perfil(Guid.NewGuid(), "Comum")
            };
        }

        static List<Domain.Usuario.Usuario> GetUsuario(List<Domain.Perfil.Perfil> perfis)
        {
            return new List<Domain.Usuario.Usuario>()
            {
                new Domain.Usuario.Usuario(Guid.NewGuid(), "Ana Caroline", "anacaroline@graphql.com", 26, true,  1000, perfis[0].Id, perfis[0], UsuarioStatus.ATIVO),
                new Domain.Usuario.Usuario(Guid.NewGuid(), "João Silva", "joaosilva@graphql.com", 26, false, 1000,  perfis[1].Id, perfis[0], UsuarioStatus.ATIVO)
            };
        }
    }
}
