using GraphQL.Domain.Usuario;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace GraphQL.Application.Repositories
{
    public interface IUsersRepository
    {
        int Add(Usuario usuario);

        int Delete(Usuario usuario);

        List<Usuario> GetUsers();

        List<Usuario> GetUsers(Expression<Func<Usuario, bool>> condition);
    }
}
