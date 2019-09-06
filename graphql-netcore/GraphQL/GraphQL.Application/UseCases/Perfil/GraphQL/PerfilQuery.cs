using GraphQL.Application.Repositories;
using GraphQL.Application.UseCases.Expressions;
using GraphQL.Types;
using System;

namespace GraphQL.Application.UseCases.Perfil.GraphQL
{
    public class PerfilQuery : ObjectGraphType, IGraphQueryMarker
    {
        public readonly IProfileRepository profileRepository;
        private readonly IMakeExpression makeExpression;

        public PerfilQuery(IProfileRepository profileRepository, IMakeExpression makeExpression)
        {
            this.profileRepository = profileRepository;
            this.makeExpression = makeExpression;

            Field<ListGraphType<PerfilType>>("perfis",
                arguments: new QueryArguments(new QueryArgument<WhereExpressionGraph> { Name = "where" }),
                resolve: context =>
                {
                    var arguments = context.GetArgument<WhereExpression>("where");

                    return (arguments != null) ?
                        this.profileRepository.GetProfile(this.makeExpression.GetExpression<Domain.Perfil.Perfil>(arguments)) :
                        this.profileRepository.GetProfile();
                });
        }
    }
}
