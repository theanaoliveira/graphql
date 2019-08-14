using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Application.Repositories
{
    public interface IUsersRepository
    {
        List<Domain.Usuario.Usuario> GetUsers();
    }
}
