using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using GraphQL.Infrastructure.Modules;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Webapi.GraphQL.Usuario;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQL.Webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ConfigurationModule(Configuration));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //GraphQL configuration
            //services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            var builder = new ContainerBuilder();

            builder.Register<IDependencyResolver>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new FuncDependencyResolver(type => context.Resolve(type));
            });

            builder.RegisterModule<ApplicationModule>();

            services.AddMvc();

            services.AddScoped<UsuarioSchema>();
            services.AddGraphQL(o => { o.ExposeExceptions = false; }).AddGraphTypes(ServiceLifetime.Scoped);

            builder.Populate(services);

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<UsuarioSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions() { GraphQLEndPoint = "/graphql" });

            app.UseMvc();
        }
    }
}
