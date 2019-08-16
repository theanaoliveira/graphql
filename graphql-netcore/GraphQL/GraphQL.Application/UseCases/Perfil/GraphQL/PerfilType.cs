using GraphQL.Types;

namespace GraphQL.Application.UseCases.Perfil.GraphQL
{
    public class PerfilType : ObjectGraphType<Domain.Perfil.Perfil>
    {
        public PerfilType()
        {
            Name = "Profile";
            Description = "Object to get informations of profile";

            Field<IdGraphType>("id");
            Field(x => x.Name).Description("Profile name");
        }
    }
}
