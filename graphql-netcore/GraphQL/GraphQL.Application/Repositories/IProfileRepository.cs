﻿using GraphQL.Domain.Perfil;
using System.Collections.Generic;

namespace GraphQL.Application.Repositories
{
    public interface IProfileRepository
    {
        List<Perfil> GetProfile();

        Perfil GetProfile(int id);

        int Add(Perfil perfil);

        int Delete(Perfil perfil);
    }
}
