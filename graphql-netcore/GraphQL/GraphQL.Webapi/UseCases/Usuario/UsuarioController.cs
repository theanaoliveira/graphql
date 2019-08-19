using GraphQL.Application.UseCases.Usuario;
using GraphQL.Webapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GraphQL.Webapi.UseCases.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioUseCase usuarioUseCase;

        public UsuarioController(IUsuarioUseCase usuarioUseCase)
        {
            this.usuarioUseCase = usuarioUseCase;
        }

        [HttpPost]
        [Route("Users")]
        public async Task<IActionResult> GetUsers([FromBody] GraphQLQuery query)
        {
            var result = await usuarioUseCase.Execute(query.Query);
            
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}