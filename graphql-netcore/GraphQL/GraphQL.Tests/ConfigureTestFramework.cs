using Autofac;
using GraphQL.Infrastructure.Modules;
using GraphQL.Webapi.Modules;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestCollectionOrderer("GraphQL.Tests.TestCaseOrdering", "GraphQL.Tests")]
[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestFramework("GraphQL.Tests.ConfigureTestFramework", "GraphQL.Tests")]
namespace GraphQL.Tests
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink) 
            : base(diagnosticMessageSink)
        {
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register<IDependencyResolver>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new FuncDependencyResolver(type => context.Resolve(type));
            });

            builder.RegisterModule<Infrastructure.Modules.Module>();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<WebApiModule>();
        }
    }
}
