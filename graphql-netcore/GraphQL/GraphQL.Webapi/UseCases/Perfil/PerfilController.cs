using System.Threading.Tasks;
using GraphQL.Application.UseCases.Perfil;
using GraphQL.Webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Webapi.UseCases.Perfil
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        public readonly IPerfilUseCase perfilUseCase;

        public PerfilController(IPerfilUseCase perfilUseCase)
        {
            this.perfilUseCase = perfilUseCase;
        }

        [HttpPost]
        [Route("Profiles")]
        public async Task<IActionResult> GetProfiles([FromBody] GraphQLQuery query)
        {
            var result = await perfilUseCase.Execute(query.Input);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}