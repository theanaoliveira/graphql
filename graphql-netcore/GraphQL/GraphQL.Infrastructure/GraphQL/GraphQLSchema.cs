using GraphQL.Infrastructure.PostgresDataAccess.Repositories;
using GraphQL.Types;

namespace GraphQL.Infrastructure.GraphQL
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<GraphQLQuery>();
            Mutation = resolver.Resolve<GraphQLMutation>();
        }
    }
}
