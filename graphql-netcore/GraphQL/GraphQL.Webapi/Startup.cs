using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using GraphQL.Infrastructure.GraphQL;
using GraphQL.Infrastructure.Modules;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Webapi.Modules;
using GraphQL.Webapi.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using System;
using System.Linq;

[assembly: ApiConventionType(typeof(ApiConventions))]
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
            services.AddMvc();
            services.AddGraphQL(o => { o.ExposeExceptions = false; }).AddGraphTypes(ServiceLifetime.Scoped);

            services.AddSwaggerDocument(document =>
            {
                document.Title = "GraphQL";
                document.Version = "v1";
                document.PostProcess = s =>
                {
                    s.Paths.ToList().ForEach(p =>
                    {
                        p.Value.Parameters.Add(
                        new OpenApiParameter()
                        {
                            Kind = OpenApiParameterKind.Header,
                            Type = NJsonSchema.JsonObjectType.String,
                            IsRequired = false,
                            Name = "Accept-Language",
                            Description = "pt-BR or en-US",
                            Default = "pt-BR"
                        });
                    });
                };
            });


            var builder = new ContainerBuilder();

            builder.Register<IDependencyResolver>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return new FuncDependencyResolver(type => context.Resolve(type));
            });

            builder.RegisterModule<Infrastructure.Modules.Module>();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<WebApiModule>();

            InfrastructureModule.RegisterInContainer((type, instance) => { services.AddSingleton(type, instance); });

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

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseGraphQL<GraphQLSchema>("/graphql");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions() { GraphQLEndPoint = "/graphql" });

            app.UseOpenApi(config =>
            {
                config.PostProcess = (document, request) =>
                {
                    document.Host = ExtractHost(request);
                    document.BasePath = ExtractPath(request);
                    document.Schemes.Clear();
                };
            });

            app.UseSwaggerUi3(config => config.TransformToExternalPath = (route, request) => ExtractPath(request) + route);

            //Redireciona swagger como pagina inicial
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseRewriter(option);
            app.UseMvc();
        }

        private string ExtractHost(HttpRequest request) =>
            request.Headers.ContainsKey("X-Forwarded-Host") ?
                new Uri($"{ExtractProto(request)}://{request.Headers["X-Forwarded-Host"].First()}").Host :
                    request.Host.Value;

        private string ExtractProto(HttpRequest request) =>
            request.Headers["X-Forwarded-Proto"].FirstOrDefault() ?? request.Protocol;

        private string ExtractPath(HttpRequest request) =>
            request.Headers.ContainsKey("X-Forwarded-Prefix") ?
                request.Headers["X-Forwarded-Prefix"].FirstOrDefault() :
                string.Empty;
    }
}
