using GraphQL.Domain.Usuario;
using System.Collections.Generic;

namespace GraphQL.Application.Repositories
{
    public interface IUsersRepository
    {
        List<Usuario> GetUsers();

        Usuario GetUsers(int id);

        int Add(Usuario usuario);

        int Delete(Usuario usuario);
    }
}
