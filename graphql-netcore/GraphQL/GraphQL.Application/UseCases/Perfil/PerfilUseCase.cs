using GraphQL.Application.Repositories;
using GraphQL.Application.UseCases.Perfil.GraphQL;
using GraphQL.Types;
using System.Threading.Tasks;

namespace GraphQL.Application.UseCases.Perfil
{
    public class PerfilUseCase : IPerfilUseCase
    {
        public readonly ISchema schema;

        public PerfilUseCase(ISchema schema)
        {
            this.schema = schema;
        }

        public async Task<ExecutionResult> Execute(string query)
        {
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query;
            }).ConfigureAwait(false);

            return result;
        }
    }
}
