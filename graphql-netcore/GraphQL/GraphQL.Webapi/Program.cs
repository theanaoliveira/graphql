using System;
using GraphQL.Application.UseCases.Usuario;
using GraphQL.Types;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GraphQL.Webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var schema = new Schema { Query = new UsuarioQuery() };

            var json = schema.Execute(e =>
            {
                e.Query = "{ user { id name age email vip} }";
            });

            Console.WriteLine(json);

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
