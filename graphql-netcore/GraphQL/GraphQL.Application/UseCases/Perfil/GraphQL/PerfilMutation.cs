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

            Field<PerfilType>("createProfile",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PerfilInput>> { Name = "perfil" }),
                resolve: context => {
                    var perfil = context.GetArgument<Domain.Perfil.Perfil>("perfil");
                    var profile = new Domain.Perfil.Perfil(Guid.NewGuid(), perfil.Name);

                    if (profile.IsValid)
                        this.profileRepository.Add(profile);
                    else
                        return new ArgumentException(string.Join(",", profile.ValidationResult.Errors));

                    return profile;
                });
        }
    }
}
