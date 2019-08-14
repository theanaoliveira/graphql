using System;

namespace GraphQL.Webapi.GraphQL
{
    public class GraphQLException : Exception
    {
        public GraphQLException(string businessMessage) 
               : base(businessMessage)
        { }
    }
}
