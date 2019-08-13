using GraphQL.Application.UseCases.Usuario;
using GraphQL.Types;

namespace GraphQL.Webapi.GraphQL
{
    public class UsuarioQuery : ObjectGraphType
    {
        public UsuarioQuery()
        {
            Field<ListGraphType<UsuarioType>>("users", resolve: context => new UsuarioUseCase().Execute());
        }
    }
}
