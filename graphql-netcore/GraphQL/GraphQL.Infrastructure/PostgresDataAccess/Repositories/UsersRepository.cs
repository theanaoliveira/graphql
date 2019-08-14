using GraphQL.Application.Repositories;
using GraphQL.Domain.Usuario;
using System.Collections.Generic;

namespace GraphQL.Infrastructure.PostgresDataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public List<Usuario> GetUsers()
        {
            var perfil = new Domain.Perfil.Perfil(1, "Administrador");

            return new List<Domain.Usuario.Usuario>() {
                    new Domain.Usuario.Usuario(1, "Ana Caroline", "anacaroline@usuario.com", 26, true, 1000, perfil, UsuarioStatus.ATIVO),
                    new Domain.Usuario.Usuario(1, "João da Silva", "joaosilva@usuario.com", 29, true, 899, perfil,  UsuarioStatus.ATIVO),
                    new Domain.Usuario.Usuario(1, "Daniela Santos", "danielasantos@usuario.com", 20, true, 5500, perfil, UsuarioStatus.BLOQUEADO),
                };
        }
    }
}
