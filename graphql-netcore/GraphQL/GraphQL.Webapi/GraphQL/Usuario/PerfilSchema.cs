using GraphQL.Application.UseCases.Perfil.GraphQL;
using GraphQL.Types;

namespace GraphQL.Webapi.GraphQL.Usuario
{
    public class PerfilSchema: Schema
    {
        public PerfilSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<PerfilQuery>();
            Mutation = resolver.Resolve<PerfilMutation>();
        }
    }
}
