using Autofac;
using GraphQL.Infrastructure.GraphQL;

namespace GraphQL.Infrastructure.Modules
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
               .AsImplementedInterfaces()
               .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<GraphQLSchema>().InstancePerLifetimeScope();
            builder.RegisterType<GraphQLQuery>().AsSelf().AsImplementedInterfaces().SingleInstance();
        }
    }
}
