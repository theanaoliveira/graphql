using AutoMapper;
using GraphQL.Application.Repositories;
using GraphQL.Domain.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IQueryable<Usuario> GetUsers(Expression<Func<Usuario, bool>> condition)
        {
            IQueryable<Usuario> user;
            
            using (var context = new Context())
            {
                user = context.Usuario.Include(i => i.Perfil).Where(condition);
            }

            return user;
        }
        
        public IQueryable<Usuario> GetUsers()
        {
            IQueryable<Usuario> user;

            using (var context = new Context())
            {
                user = context.Usuario.Include(i => i.Perfil);
            }

            return user;
        }
    }
}
