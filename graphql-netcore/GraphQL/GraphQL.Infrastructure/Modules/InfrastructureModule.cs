using Autofac;
using GraphQL.EntityFramework;
using GraphQL.Infrastructure.GraphQL;
using GraphQL.Infrastructure.PostgresDataAccess;
using GraphQL.Types;
using GraphQL.Utilities;
using System;
using System.Collections.Generic;

namespace GraphQL.Infrastructure.Modules
{
    public class InfrastructureModule : Autofac.Module
    {
        static Dictionary<Type, GraphType> entries = new Dictionary<Type, GraphType>();

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
               .AsImplementedInterfaces()
               .AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<IEfGraphQLService<Context>>();
            builder.RegisterType<GraphQLSchema>().InstancePerLifetimeScope();
            builder.RegisterType<GraphQLQuery>().AsSelf().AsImplementedInterfaces().SingleInstance();

            entries.Add(typeof(WhereExpressionGraph), new WhereExpressionGraph());
        }

        public static void RegisterInContainer(Action<Type, GraphType> registerInstance)
        {
            foreach (var entry in entries)
            {
                registerInstance(entry.Key, entry.Value);
            }
        }
    }
}
