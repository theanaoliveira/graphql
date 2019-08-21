using GraphQL.Application.Repositories;
using GraphQL.Application.UseCases.Usuario.GraphQL;
using GraphQL.Types;
using System.Threading.Tasks;

namespace GraphQL.Application.UseCases.Usuario
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IUsersRepository usersRepository;
        private readonly IProfileRepository profileRepository;

        public UsuarioUseCase(IUsersRepository usersRepository, IProfileRepository profileRepository)
        {
            this.usersRepository = usersRepository;
            this.profileRepository = profileRepository;
        }

        public async Task<ExecutionResult> Execute(string query)
        {
            //var schema = new Schema
            //{
            //    Query = new UsuarioQuery(usersRepository),
            //    Mutation = new UsuarioMutation(usersRepository, profileRepository)
            //};

            //var result = await new DocumentExecuter().ExecuteAsync(_ =>
            //{
            //    _.Schema = usersRepository.Test(query);
            //    _.Query = query;

            //}).ConfigureAwait(false);

            var result = await usersRepository.Test(query);

            return result;
        }
    }
}
