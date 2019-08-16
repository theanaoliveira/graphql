using GraphQL.Application.Repositories;
using GraphQL.Types;

namespace GraphQL.Application.UseCases.Perfil.GraphQL
{
    public class PerfilQuery : ObjectGraphType, IGraphQueryMarker
    {
        public readonly IProfileRepository profileRepository;

        public PerfilQuery(IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;

            Field<ListGraphType<PerfilType>>("perfis", resolve: context => this.profileRepository.GetProfile());

            Field<PerfilType>("perfil",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return profileRepository.GetProfile(id);
                });
        }
    }
}
