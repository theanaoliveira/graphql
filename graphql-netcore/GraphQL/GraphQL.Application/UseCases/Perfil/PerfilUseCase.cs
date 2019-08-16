using GraphQL.Application.Repositories;
using GraphQL.Application.UseCases.Perfil.GraphQL;
using GraphQL.Types;
using System.Threading.Tasks;

namespace GraphQL.Application.UseCases.Perfil
{
    public class PerfilUseCase : IPerfilUseCase
    {
        public readonly IProfileRepository profileRepository;

        public PerfilUseCase(IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        public async Task<ExecutionResult> Execute(string query)
        {
            var schema = new Schema { Query = new PerfilQuery(profileRepository) };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query;
            }).ConfigureAwait(false);

            return result;
        }
    }
}
