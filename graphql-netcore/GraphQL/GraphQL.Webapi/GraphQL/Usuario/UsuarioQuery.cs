using GraphQL.Application.Repositories;
using GraphQL.Types;

namespace GraphQL.Webapi.GraphQL.Usuario
{
    public class UsuarioQuery : ObjectGraphType
    {
        private readonly IUsuarioUseCase usuarioUseCase;
                
        public UsuarioQuery(IUsuarioUseCase usuarioUseCase)
        {
            this.usuarioUseCase = usuarioUseCase;
            Field<ListGraphType<UsuarioType>>("users", resolve: context => this.usuarioUseCase.Execute());
        }
    }
}
