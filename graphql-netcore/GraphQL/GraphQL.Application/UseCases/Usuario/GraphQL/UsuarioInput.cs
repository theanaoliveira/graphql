using GraphQL.Application.UseCases.Perfil.GraphQL;
using GraphQL.Types;

namespace GraphQL.Application.UseCases.Usuario.GraphQL
{
    public class UsuarioInput : InputObjectGraphType
    {
        public UsuarioInput()
        {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<IntGraphType>>("age");
            Field<BooleanGraphType>("vip");
            Field<NonNullGraphType<FloatGraphType>>("salario");
            Field<UsuarioStatusType>("status");
        }
    }
}
