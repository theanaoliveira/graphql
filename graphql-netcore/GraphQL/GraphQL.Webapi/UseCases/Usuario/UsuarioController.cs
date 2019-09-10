using GraphQL.Application.Repositories;
using GraphQL.Webapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GraphQL.Webapi.UseCases.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IGraphQLRepository graphQLRepository;

        public UsuarioController(IGraphQLRepository graphQLRepository)
        {
            this.graphQLRepository = graphQLRepository;
        }

        [HttpPost]
        [Route("Users")]
        public async Task<IActionResult> GetUsers([FromBody] GraphQLQuery query)
        {
            var result = await graphQLRepository.Execute(query.Input);
            
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}