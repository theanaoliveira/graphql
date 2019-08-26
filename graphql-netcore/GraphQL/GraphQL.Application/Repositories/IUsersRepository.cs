using GraphQL.Domain.Usuario;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GraphQL.Application.Repositories
{
    public interface IUsersRepository
    {
        int Add(Usuario usuario);

        int Delete(Usuario usuario);

        IQueryable<Usuario> GetUsers();

        Usuario GetUsers(Guid id);

        Task<ExecutionResult> Test(string query);
    }
}
