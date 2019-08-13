using GraphQL.Domain.Usuario;
using GraphQL.Types;

namespace GraphQL.Application.UseCases.Usuario
{
    public class UsuarioQuery : ObjectGraphType
    {
        public UsuarioQuery()
        {
            Field<UsuarioType>("user",
                resolve: context => new Domain.Usuario.Usuario
                { Id = 1, Name = "Ana Caroline", Age = 26, Email = "anacaroline@usuario.com", Vip = true });
        }
    }
}
