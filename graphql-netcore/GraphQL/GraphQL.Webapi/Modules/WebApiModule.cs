using Autofac;
using GraphQL.Webapi.GraphQL;

namespace GraphQL.Webapi.Modules
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(GraphQLException).Assembly)
                .InstancePerLifetimeScope();
        }
    }
}
