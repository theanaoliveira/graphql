using GraphQL.Types;

namespace GraphQL.Domain.Usuario
{
    public class UsuarioType : ObjectGraphType<Usuario>
    {
        public UsuarioType()
        {
            Name = "User";
            Description = "Object to get informations of user";

            Field(x => x.Id).Description("Id of user");
            Field(x => x.Name).Description("Name of user");
            Field(x => x.Email).Description("E-mail of user");
            Field(x => x.Age).Description("Age of user");
            Field(x => x.Vip).Description("If this user is vip");
        }
    }
}
