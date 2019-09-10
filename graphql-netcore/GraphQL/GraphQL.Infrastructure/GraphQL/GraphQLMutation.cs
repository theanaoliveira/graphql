using GraphQL.Application.Repositories;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Infrastructure.GraphQL
{
    public class GraphQLMutation : ObjectGraphType<object>
    {
        public GraphQLMutation(IEnumerable<IGraphMutationMarker> graphQueryMarkers)
        {
            Name = "GraphQLMutation";

            graphQueryMarkers.ToList().ForEach(f =>
            {
                var mutation = f as ObjectGraphType<object>;
                mutation.Fields.ToList().ForEach(q => AddField(q));
            });
        }
    }
}
