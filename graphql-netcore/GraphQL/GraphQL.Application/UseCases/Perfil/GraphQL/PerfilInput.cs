using GraphQL.Types;

namespace GraphQL.Application.UseCases.Perfil.GraphQL
{
    public class PerfilInput : InputObjectGraphType
    {
        public PerfilInput()
        {
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
