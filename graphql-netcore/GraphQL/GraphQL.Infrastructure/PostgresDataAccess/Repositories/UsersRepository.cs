using AutoMapper;
using GraphQL.Application.Repositories;
using GraphQL.Domain.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Infrastructure.PostgresDataAccess.Repositories
{
    public class UsersRepository : IUsersRepository, IDisposable
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

        public Usuario GetUsers(Guid id)
            => context.Usuario
                .Include(i => i.Perfil)
                .FirstOrDefault(w => w.Id.Equals(id));

        public IQueryable<Usuario> GetUsers()
            => context.Usuario.Include(i => i.Perfil);

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
