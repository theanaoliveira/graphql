using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Application.UseCases.Usuario
{
    public interface IUsuarioUseCase
    {
        Task<ExecutionResult> Execute(string query);
    }
}
