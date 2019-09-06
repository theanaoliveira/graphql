using GraphQL.Application.Repositories;
using GraphQL.Application.UseCases.Expressions;
using GraphQL.Types;
using System;

namespace GraphQL.Application.UseCases.Perfil.GraphQL
{
    public class PerfilMutation : ObjectGraphType, IGraphMutationMarker
    {
        private readonly IProfileRepository profileRepository;
        private readonly IMakeExpression makeExpression;

        public PerfilMutation(IProfileRepository profileRepository, IMakeExpression makeExpression)
        {
            this.profileRepository = profileRepository;
            this.makeExpression = makeExpression;

            Profiles();
        }

        public void Profiles()
        {
            Field<PerfilType>("createProfile",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }),
                resolve: context => AddProfile(context));

            Field<PerfilType>("deleteProfile",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<WhereExpressionGraph>> { Name = "where" }),
                resolve: context => DeleteProfile(context));
        }

        public object AddProfile(ResolveFieldContext<object> context)
        {
            var name = context.GetArgument<string>("name");
            var profile = new Domain.Perfil.Perfil(Guid.NewGuid(), name);

            if (profile.IsValid)
                this.profileRepository.Add(profile);
            else
                return new ArgumentException(string.Join(",", profile.ValidationResult.Errors));

            return profile;
        }

        public object DeleteProfile(ResolveFieldContext<object> context)
        {
            var where = context.GetArgument<WhereExpression>("where");
            var perfil = this.profileRepository.GetProfile(makeExpression.GetExpression<Domain.Perfil.Perfil>(where));

            if (perfil != null)
                this.profileRepository.Delete(perfil[0]);
            else
                return new ArgumentException($"Perfil: {where.Value} não encontrado.");

            return perfil;
        }
    }
}
