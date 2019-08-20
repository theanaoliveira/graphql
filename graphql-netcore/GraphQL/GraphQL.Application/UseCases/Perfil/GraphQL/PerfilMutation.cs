using GraphQL.Application.Repositories;
using GraphQL.Types;
using System;

namespace GraphQL.Application.UseCases.Perfil.GraphQL
{
    public class PerfilMutation : ObjectGraphType, IGraphMutationMarker
    {
        private readonly IProfileRepository profileRepository;

        public PerfilMutation(IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;

            Profiles();
        }

        public void Profiles()
        {
            Field<PerfilType>("createProfile",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }),
                resolve: context => AddProfile(context));

            Field<PerfilType>("deleteProfile",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
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
            var id = context.GetArgument<Guid>("id");
            var perfil = this.profileRepository.GetProfile(id);

            if (perfil != null)
                this.profileRepository.Delete(perfil);
            else
                return new ArgumentException($"Perfil: {id} não encontrado.");

            return perfil;
        }
    }
}
