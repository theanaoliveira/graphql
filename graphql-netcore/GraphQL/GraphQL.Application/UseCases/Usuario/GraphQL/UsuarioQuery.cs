using GraphQL.Application.Repositories;
using GraphQL.Types;

namespace GraphQL.Application.UseCases.Usuario.GraphQL
{
    public class UsuarioQuery : ObjectGraphType, IGraphQueryMarker
    {
        private readonly IUsuarioUseCase usuarioUseCase;
                
        public UsuarioQuery(IUsuarioUseCase usuarioUseCase)
        {
            this.usuarioUseCase = usuarioUseCase;
            Field<ListGraphType<UsuarioType>>("users", resolve: context => this.usuarioUseCase.Execute());
        }
    }
}
