using GraphQL.Domain.Perfil;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GraphQL.Application.Repositories
{
    public interface IProfileRepository
    {
        List<Perfil> GetProfile();

        List<Perfil> GetProfile(Expression<Func<Perfil, bool>> condition);

        int Add(Perfil perfil);

        int Delete(Perfil perfil);
    }
}
