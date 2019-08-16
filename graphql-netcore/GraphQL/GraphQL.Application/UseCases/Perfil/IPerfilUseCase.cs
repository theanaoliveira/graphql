using System.Threading.Tasks;

namespace GraphQL.Application.UseCases.Perfil
{
    public interface IPerfilUseCase
    {
        Task<ExecutionResult> Execute(string query);
    }
}
