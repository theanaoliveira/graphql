﻿using AutoMapper;
using GraphQL.Application.Repositories;
using GraphQL.Domain.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphQL.Infrastructure.PostgresDataAccess.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        public readonly IMapper mapper;

        public ProfileRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public List<Perfil> GetProfile()
        {
            var perfis = new List<Perfil>();

            using (var context = new Context())
            {
                perfis = mapper.Map<List<Perfil>>(context.Perfil.ToList());
            }

            return perfis;
        }

        public Perfil GetProfile(int id)
        {
            using (var context = new Context())
            {
                return mapper.Map<Perfil>(context.Perfil.Where(w => w.Id == id).FirstOrDefault());
            }
        }
    }
}
