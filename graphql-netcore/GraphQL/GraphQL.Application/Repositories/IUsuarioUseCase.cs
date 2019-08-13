using System.Collections.Generic;

namespace GraphQL.Application.Repositories
{
    public interface IUsuarioUseCase
    {
        List<Domain.Usuario.Usuario> Execute();
    }
}
