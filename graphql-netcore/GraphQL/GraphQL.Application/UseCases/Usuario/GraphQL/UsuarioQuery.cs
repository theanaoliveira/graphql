using GraphQL.Application.Repositories;
using GraphQL.Types;
using System;

namespace GraphQL.Application.UseCases.Usuario.GraphQL
{
    public class UsuarioQuery : ObjectGraphType, IGraphQueryMarker
    {
        private readonly IUsersRepository usersRepository;

        public UsuarioQuery(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;

            Field<ListGraphType<UsuarioType>>("users", resolve: context => this.usersRepository.GetUsers());

            Field<UsuarioType>("user",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context => this.usersRepository.GetUsers(context.GetArgument<Guid>("id")));
        }
    }
}
