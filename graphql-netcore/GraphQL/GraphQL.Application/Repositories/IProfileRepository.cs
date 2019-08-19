using GraphQL.Domain.Perfil;
using System;
using System.Collections.Generic;

namespace GraphQL.Application.Repositories
{
    public interface IProfileRepository
    {
        List<Perfil> GetProfile();

        Perfil GetProfile(Guid id);

        Perfil GetProfile(string name);

        int Add(Perfil perfil);

        int Delete(Perfil perfil);
    }
}
