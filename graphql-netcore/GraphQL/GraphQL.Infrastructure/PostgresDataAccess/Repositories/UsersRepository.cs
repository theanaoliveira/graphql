using GraphQL.Application.Repositories;
using GraphQL.Domain.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GraphQL.Infrastructure.PostgresDataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public int Add(Usuario usuario)
        {
            using (var context = new Context())
            {
                context.Usuario.Add(usuario);
                return context.SaveChanges();
            }
        }

        public int Delete(Usuario usuario)
        {
            using (var context = new Context())
            {
                context.Usuario.Remove(usuario);
                return context.SaveChanges();
            }
        }

        public List<Usuario> GetUsers(Expression<Func<Usuario, bool>> condition)
        {
            using (var context = new Context())
            {
                return context.Usuario.Where(condition).ToList();
            }
        }

        public List<Usuario> GetUsers()
        {
            using (var context = new Context())
            {
                return context.Usuario.ToList();
            }
        }
    }
}
