using GraphQL.Domain.Perfil;
using GraphQL.Domain.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;

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
                new Perfil(Guid.NewGuid(), "Administrador"),
                new Perfil(Guid.NewGuid(), "Comum"),
            };
        }

        static List<Domain.Usuario.Usuario> GetUsuario(List<Domain.Perfil.Perfil> perfis)
        {
            return new List<Domain.Usuario.Usuario>()
            {
                new Usuario(Guid.NewGuid(), "Ana Caroline", "anacaroline@graphql.com", 26, true, 1000, perfis[0].Id, perfis[0], UsuarioStatus.ATIVO),
                new Usuario(Guid.NewGuid(), "João Silva", "joaosilva@graphql.com", 30, false, 1000, perfis[1].Id, perfis[1], UsuarioStatus.ATIVO),
            };
        }
    }
}
