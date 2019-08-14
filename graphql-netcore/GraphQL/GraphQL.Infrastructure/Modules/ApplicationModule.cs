using Autofac;
using GraphQL.Application;
using GraphQL.Infrastructure.GraphQL;

namespace GraphQL.Infrastructure.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ApplicationException).Assembly)
                .AsImplementedInterfaces()
                .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<GraphQLSchema>().InstancePerLifetimeScope();
            builder.RegisterType<GraphQLQuery>().AsSelf().AsImplementedInterfaces().SingleInstance();
        }
    }
}
