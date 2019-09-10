using GraphQL.Application.Repositories;
using System.Threading.Tasks;

namespace GraphQL.Application.UseCases.Perfil
{
    public class PerfilUseCase : IPerfilUseCase
    {
        public readonly IGraphQLRepository graphQLRepository;

        public PerfilUseCase(IGraphQLRepository graphQLRepository)
        {
            this.graphQLRepository = graphQLRepository;
        }

        public async Task<ExecutionResult> Execute(string query)
        {
            var result = await graphQLRepository.Execute(query);

            return result;
        }
    }
}
