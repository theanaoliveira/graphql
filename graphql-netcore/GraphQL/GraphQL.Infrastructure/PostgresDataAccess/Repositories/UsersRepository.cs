using AutoMapper;
using GraphQL.Application.Repositories;
using GraphQL.Domain.Usuario;
using GraphQL.EntityFramework;
using GraphQL.Infrastructure.GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                // context.Usuario.Add(mapper.Map<Entities.Usuario>(usuario));
                return context.SaveChanges();
            }
        }

        public int Delete(Usuario usuario)
        {
            using (var context = new Context())
            {
                //context.Usuario.Remove(mapper.Map<Entities.Usuario>(usuario));
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

        public Usuario GetUsers(Guid id)
        {
            using (var context = new Context())
            {
                return mapper.Map<Usuario>(context.Usuario.Include(i => i.Perfil).FirstOrDefault(w => w.Id == id));
            }
        }

        public Task<ExecutionResult> Test(string query)
        {
            using (var context = new Context())
            {
                var schema = new Schema
                {
                    Query = new Query(context),
                };

                var executionOptions = new ExecutionOptions
                {
                    Schema = schema,
                    Query = query,
                    UserContext = context,
                };

                return new DocumentExecuter().ExecuteAsync(executionOptions);
            }

        }

        static IEnumerable<Type> GetGraphQlTypes()
        {
            return typeof(InfrastructureException).Assembly
                .GetTypes()
                .Where(x => !x.IsAbstract && typeof(GraphType).IsAssignableFrom(x));
        }
    }
}
