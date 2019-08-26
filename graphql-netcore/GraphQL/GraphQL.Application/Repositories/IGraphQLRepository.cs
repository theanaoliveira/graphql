using System.Threading.Tasks;

namespace GraphQL.Application.Repositories
{
    public interface IGraphQLRepository
    {
        Task<ExecutionResult> Execute(string query);
    }
}
