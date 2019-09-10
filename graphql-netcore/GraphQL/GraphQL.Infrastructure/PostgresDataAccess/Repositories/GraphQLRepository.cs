using GraphQL.Application.Repositories;
using GraphQL.Infrastructure.PostgresDataAccess;
using GraphQL.Types;
using System.Threading.Tasks;

namespace GraphQL.Infrastructure.PostgresDataAccess.Repositories
{
    public class GraphQLRepository : IGraphQLRepository
    {
        public readonly ISchema schema;

        public GraphQLRepository(ISchema schema)
        {
            this.schema = schema;
        }

        public async Task<ExecutionResult> Execute(string query)
        {
            return await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query;
                _.UserContext = new Context();
            });
        }
    }
}
