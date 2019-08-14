using GraphQL.Application.Repositories;
using System.Collections.Generic;

namespace GraphQL.Application.UseCases.Perfil
{
    public class PerfilUseCase : IPerfilUseCase
    {
        public List<Domain.Perfil.Perfil> Execute()
        {
            return new List<Domain.Perfil.Perfil>()
            {
                new Domain.Perfil.Perfil(1, "Administrador"),
                new Domain.Perfil.Perfil(2, "Comum")
            };
        }
    }
}
