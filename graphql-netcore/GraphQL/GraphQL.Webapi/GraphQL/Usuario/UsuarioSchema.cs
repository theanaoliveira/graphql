using GraphQL.Application.UseCases.Perfil.GraphQL;
using GraphQL.Application.UseCases.Usuario.GraphQL;
using GraphQL.Types;

namespace GraphQL.Webapi.GraphQL.Usuario
{
    public class UsuarioSchema : Schema
    {
        public UsuarioSchema(IDependencyResolver resolver) : base(resolver)
        {           
            Query = resolver.Resolve<UsuarioQuery>();
            Mutation = resolver.Resolve<UsuarioMutation>();
        }
    }
}
