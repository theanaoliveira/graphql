using GraphQL.Application.Repositories;
using GraphQL.Types;

namespace GraphQL.Application.UseCases.Usuario.GraphQL
{
    public class UsuarioQuery : ObjectGraphType, IGraphQueryMarker
    {
        private readonly IUsersRepository usersRepository;

        public UsuarioQuery(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
            Field<ListGraphType<UsuarioType>>("users", resolve: context => this.usersRepository.GetUsers());
        }
    }
}
