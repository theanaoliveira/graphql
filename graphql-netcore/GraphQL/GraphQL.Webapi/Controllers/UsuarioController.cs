using GraphQL.Client;
using GraphQL.Common.Request;
using GraphQL.Domain.Usuario;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Usuario>> GetAsync()
        {
            using (var graphQL = new GraphQLClient("http://localhost:8081/graphql"))
            {
                var query = new GraphQLRequest
                {
                    Query = @" 
                        { users 
                            { name email } 
                        }",
                };

                var response = await graphQL.PostAsync(query);
                return response.GetDataFieldAs<List<Usuario>>("users");
            }
        }
    }
}