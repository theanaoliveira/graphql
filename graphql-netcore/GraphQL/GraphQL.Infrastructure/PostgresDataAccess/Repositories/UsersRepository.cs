using AutoMapper;
using GraphQL.Application.Repositories;
using GraphQL.Domain.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GraphQL.Infrastructure.PostgresDataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public readonly IMapper mapper;
        public readonly Context context;

        public UsersRepository(IMapper mapper, Context context)
        {
            this.mapper = mapper;
            this.context = context;
        }

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
            List<Usuario> user;
            
            using (var context = new Context())
            {
                user = context.Usuario.Include(i => i.Perfil).Where(condition).ToList();
            }

            return user;
        }

        public List<Usuario> GetUsers()
        {
            List<Usuario> user;

            using (var context = new Context())
            {
                user = context.Usuario.Include(i => i.Perfil).ToList();
            }

            return user;
        }
    }
}
