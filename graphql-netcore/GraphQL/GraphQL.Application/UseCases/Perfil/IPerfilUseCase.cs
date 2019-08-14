using System.Collections.Generic;

namespace GraphQL.Application.UseCases.Perfil
{
    public interface IPerfilUseCase
    {
        List<Domain.Perfil.Perfil> Execute();
    }
}
