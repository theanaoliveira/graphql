using GraphQL.Domain.Usuario;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace GraphQL.Application.Repositories
{
    public interface IUsersRepository
    {
        int Add(Usuario usuario);

        int Delete(Usuario usuario);

        List<Usuario> GetUsers(Expression<Func<Usuario, bool>> condition);

        List<Usuario> GetUsers();
    }
}
