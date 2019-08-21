using GraphQL.Application.UseCases.Perfil.GraphQL;
using GraphQL.Application.UseCases.Usuario.GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Infrastructure.PostgresDataAccess.Repositories
{
    public class Query : ObjectGraphType
    {
        public Query(Context context)
        {
            Field<ListGraphType<UsuarioType>>("users", resolve: ctx =>
            {
                return context.Usuario.Include(i => i.Perfil);
            });
            Field<ListGraphType<PerfilType>>("perfis", resolve: ctx => context.Perfil);
        }
    }
}
