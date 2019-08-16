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

        static List<Perfil> GetPerfis()
        {
            return new List<Perfil>()
            {
                new Perfil(){ Id = 1, Name = "Administrador" },
                new Perfil(){ Id = 2, Name = "Comum" },
            };
        }

        static List<Usuario> GetUsuario(List<Perfil> perfis)
        {
            return new List<Usuario>()
            {
                new Usuario() { Id = 1, Name = "Ana Caroline", Age = 26, Email = "carolineana363@gmail.com", Salario = 1000, Perfil = perfis[0], Status = Domain.Usuario.UsuarioStatus.ATIVO, Vip = true },
                new Usuario() { Id = 2, Name = "João Silva", Age = 30, Email = "joaosilva@gmail.com", Salario = 1000, Perfil = perfis[1], Status = Domain.Usuario.UsuarioStatus.ATIVO, Vip = false }
            };
        }
    }
}
