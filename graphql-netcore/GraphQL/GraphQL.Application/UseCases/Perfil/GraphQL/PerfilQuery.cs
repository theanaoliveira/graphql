using GraphQL.Application.Repositories;
using GraphQL.Types;

namespace GraphQL.Application.UseCases.Perfil.GraphQL
{
    public class PerfilQuery : ObjectGraphType, IGraphQueryMarker
    {
        private readonly IPerfilUseCase perfilUseCase;

        public PerfilQuery(IPerfilUseCase perfilUseCase)
        {
            this.perfilUseCase = perfilUseCase;
            Field<ListGraphType<PerfilType>>("perfil", resolve: context => this.perfilUseCase.Execute());
        }
    }
}
