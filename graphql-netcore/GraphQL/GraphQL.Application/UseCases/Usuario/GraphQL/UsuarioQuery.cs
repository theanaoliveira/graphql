using GraphQL.Application.Repositories;
using GraphQL.Application.UseCases.Expressions;
using GraphQL.Types;
using System.Linq;

namespace GraphQL.Application.UseCases.Usuario.GraphQL
{
    public class UsuarioQuery : ObjectGraphType, IGraphQueryMarker
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMakeExpression makeExpression;

        public UsuarioQuery(IUsersRepository usersRepository, IMakeExpression makeExpression)
        {
            this.makeExpression = makeExpression;
            this.usersRepository = usersRepository;

            Field<ListGraphType<UsuarioType>>("users",
                arguments: new QueryArguments(new QueryArgument<WhereExpressionGraph> { Name = "where" }),
                resolve: context =>
                {
                    var arguments = context.GetArgument<WhereExpression>("where");
                    
                    return (arguments != null) ?
                        this.usersRepository.GetUsers(this.makeExpression.GetExpression<Domain.Usuario.Usuario>(arguments)) :
                        this.usersRepository.GetUsers().ToList();
                });
        }
    }
}
