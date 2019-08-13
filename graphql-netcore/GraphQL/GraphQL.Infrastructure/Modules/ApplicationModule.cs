using Autofac;
using GraphQL.Types;

namespace GraphQL.Infrastructure.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Application.UseCases.Usuario.UsuarioUseCase).Assembly)
                .AsImplementedInterfaces()
                .AsSelf().InstancePerLifetimeScope();
        }
    }
}
