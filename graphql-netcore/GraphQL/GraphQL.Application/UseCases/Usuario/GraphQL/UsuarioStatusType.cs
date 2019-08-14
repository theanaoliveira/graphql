using GraphQL.Domain.Usuario;
using GraphQL.Types;

namespace GraphQL.Application.UseCases.Usuario.GraphQL
{
    public class UsuarioStatusType: EnumerationGraphType<UsuarioStatus>
    {
        public UsuarioStatusType()
        {
            AddValue("ATIVO", "", 1);
            AddValue("INATIVO", "", 2);
            AddValue("BLOQUEADO", "", 3);
        }
    }
}