using GraphQL.Application.Repositories;
using GraphQL.Types;
using System;

namespace GraphQL.Application.UseCases.Usuario.GraphQL
{
    public class UsuarioMutation : ObjectGraphType, IGraphMutationMarker
    {
        private readonly IUsersRepository usersRepository;
        private readonly IProfileRepository profileRepository;

        public UsuarioMutation(IUsersRepository usersRepository, IProfileRepository profileRepository)
        {
            this.usersRepository = usersRepository;
            this.profileRepository = profileRepository;

            Users();
        }

        public void Users()
        {
            Field<UsuarioType>("createUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UsuarioInput>> { Name = "usuario" }),
                resolve: context => AddUser(context));

            Field<UsuarioType>("deleteUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context => DeleteUser(context));
        }

        private object AddUser(ResolveFieldContext<object> context)
        {
            var usuario = context.GetArgument<Domain.Usuario.Usuario>("usuario");
            var perfil = this.profileRepository.GetProfile("Comum");
            var user = new Domain.Usuario.Usuario(Guid.NewGuid(), usuario.Name, usuario.Email, usuario.Age, usuario.Vip, usuario.Salario, perfil.Id, null, usuario.Status);

            if (user.IsValid)
                this.usersRepository.Add(user);
            else
                return new ArgumentException(string.Join(",", user.ValidationResult.Errors));

            return user;
        }

        private object DeleteUser(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<Guid>("id");
            var usuario = usersRepository.GetUsers(id).As<Domain.Usuario.Usuario>();

            if (usuario != null)
                usersRepository.Delete(usuario);
            else
                return new ArgumentException($"Usuario: {id} não encontrado.");

            return usuario;
        }
    }
}
