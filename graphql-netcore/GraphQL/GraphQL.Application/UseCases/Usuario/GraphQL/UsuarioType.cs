using GraphQL.Application.UseCases.Perfil.GraphQL;
using GraphQL.Types;

namespace GraphQL.Application.UseCases.Usuario.GraphQL
{
    public class UsuarioType : ObjectGraphType<Domain.Usuario.Usuario>
    {
        public UsuarioType()
        {
            Name = "User";
            Description = "Object to get informations of user";

            Field<IdGraphType>("id");
            Field(x => x.Name).Description("Name of user");
            Field(x => x.Email).Description("E-mail of user");
            Field(x => x.Age, nullable: true).Description("Age of user");
            Field(x => x.Vip, nullable: true).Description("If this user is vip");
            Field(x => x.Salario, nullable: true);
            Field<UsuarioStatusType>("status");
            Field<PerfilType>("perfil");
        }
    }
}
