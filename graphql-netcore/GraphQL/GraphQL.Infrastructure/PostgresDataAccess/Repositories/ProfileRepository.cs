using AutoMapper;
using GraphQL.Application.Repositories;
using GraphQL.Domain.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GraphQL.Infrastructure.PostgresDataAccess.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        public readonly IMapper mapper;

        public ProfileRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(Perfil perfil)
        {
            using (var context = new Context())
            {
                context.Perfil.Add(perfil);
                return context.SaveChanges();
            }
        }

        public int Delete(Perfil perfil)
        {
            using (var context = new Context())
            {
                context.Perfil.Remove(perfil);
                return context.SaveChanges();
            }
        }

        public List<Perfil> GetProfile()
        {
            var perfis = new List<Perfil>();

            using (var context = new Context())
            {
                return context.Perfil.ToList();
            }
        }

        public List<Perfil> GetProfile(Expression<Func<Perfil, bool>> condition)
        {
            using (var context = new Context())
            {
                return context.Perfil.Where(condition).ToList();
            }
        }
    }
}
