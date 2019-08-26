using GraphQL.Application.Repositories;
using System.Threading.Tasks;

namespace GraphQL.Application.UseCases.Usuario
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        public readonly IGraphQLRepository graphQLRepository;

        public UsuarioUseCase(IGraphQLRepository graphQLRepository)
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
