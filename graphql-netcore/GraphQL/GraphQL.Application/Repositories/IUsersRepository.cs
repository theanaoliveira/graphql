using GraphQL.Domain.Usuario;
using System.Collections.Generic;

namespace GraphQL.Application.Repositories
{
    public interface IUsersRepository
    {
        List<Usuario> GetUsers();

        Usuario GetUsers(int id);
    }
}
