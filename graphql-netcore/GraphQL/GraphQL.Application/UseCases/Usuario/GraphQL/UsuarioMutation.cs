using GraphQL.Application.Repositories;
using GraphQL.Application.UseCases.Expressions;
using GraphQL.Application.UseCases.Expressions.Where;
using GraphQL.Types;
using System;

namespace GraphQL.Application.UseCases.Usuario.GraphQL
{
    public class UsuarioMutation : ObjectGraphType, IGraphMutationMarker
    {
        private readonly IUsersRepository usersRepository;
        private readonly IProfileRepository profileRepository;
        private readonly IMakeExpression makeExpression;

        public UsuarioMutation(IUsersRepository usersRepository, IProfileRepository profileRepository, IMakeExpression makeExpression)
        {
            this.usersRepository = usersRepository;
            this.profileRepository = profileRepository;
            this.makeExpression = makeExpression;

            Users();
        }

        public void Users()
        {
            Field<UsuarioType>("createUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UsuarioInput>> { Name = "usuario" }),
                resolve: context => AddUser(context));

            Field<UsuarioType>("deleteUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<WhereExpressionGraph>> { Name = "where" }),
                resolve: context => DeleteUser(context));
        }

        private object AddUser(ResolveFieldContext<object> context)
        {
            var usuario = context.GetArgument<Domain.Usuario.Usuario>("usuario");
            var perfil = this.profileRepository.GetProfile(p=> p.Name == "Comum");
            var user = new Domain.Usuario.Usuario(Guid.NewGuid(), usuario.Name, usuario.Email, usuario.Age, usuario.Vip, usuario.Salario, perfil[0].Id, null, usuario.Status);

            if (user.IsValid)
                this.usersRepository.Add(user);
            else
                return new ArgumentException(string.Join(",", user.ValidationResult.Errors));

            return user;
        }

        private object DeleteUser(ResolveFieldContext<object> context)
        {
            var arguments = context.GetArgument<WhereExpression>("where");
            var usuario = usersRepository.GetUsers(this.makeExpression.GetExpression<Domain.Usuario.Usuario>(arguments));

            if (usuario != null)
                usersRepository.Delete(usuario[0]);
            else
                return new ArgumentException($"Usuario não encontrado.");

            return usuario;
        }
    }
}
