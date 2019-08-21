using GraphQL.Domain.Usuario;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Application.Repositories
{
    public interface IUsersRepository
    {
        List<Usuario> GetUsers();

        Usuario GetUsers(Guid id);

        int Add(Usuario usuario);

        int Delete(Usuario usuario);

        Task<ExecutionResult> Test(string query);
    }
}
