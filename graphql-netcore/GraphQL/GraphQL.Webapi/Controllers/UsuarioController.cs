using GraphQL.Types;
using GraphQL.Webapi.GraphQL;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private string Users()
        {
            var schema = new Schema { Query = new UsuarioQuery() };

            var json = schema.Execute(e =>
            {
                e.Query = "{ user { id name age email vip status} }";
            });

            return json;
        }


        [HttpGet]
        public string Get()
        {
            return Users();
        }
    }
}