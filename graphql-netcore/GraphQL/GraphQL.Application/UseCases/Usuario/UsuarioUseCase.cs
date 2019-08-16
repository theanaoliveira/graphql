using GraphQL.Application.Repositories;
using GraphQL.Application.UseCases.Usuario.GraphQL;
using GraphQL.Types;
using System.Threading.Tasks;

namespace GraphQL.Application.UseCases.Usuario
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IUsersRepository usersRepository;

        public UsuarioUseCase(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<ExecutionResult> Execute(string query)
        {
            var schema = new Schema { Query = new UsuarioQuery(usersRepository) };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query;
            }).ConfigureAwait(false);

            return result;
        }
    }
}
