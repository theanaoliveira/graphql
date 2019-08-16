using AutoMapper;
using GraphQL.Application.Repositories;
using GraphQL.Domain.Usuario;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Infrastructure.PostgresDataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public readonly IMapper mapper;

        public UsersRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(Usuario usuario)
        {
            using (var context = new Context())
            {
                context.Usuario.Add(mapper.Map<Entities.Usuario>(usuario));
                return context.SaveChanges();
            }
        }

        public int Delete(Usuario usuario)
        {
            using (var context = new Context())
            {
                context.Usuario.Remove(mapper.Map<Entities.Usuario>(usuario));
                return context.SaveChanges();
            }
        }

        public List<Usuario> GetUsers()
        {
            var usuarios = new List<Usuario>();

            using (var context = new Context())
            {
                usuarios = mapper.Map<List<Usuario>>(context.Usuario.Include(i => i.Perfil).ToList());
            }

            return usuarios;
        }

        public Usuario GetUsers(int id)
        {
            using (var context = new Context())
            {
                return mapper.Map<Usuario>(context.Usuario.Include(i => i.Perfil).Where(w => w.Id == id).FirstOrDefault());
            }
        }
    }
}
