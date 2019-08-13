﻿using GraphQL.Types;

namespace GraphQL.Webapi.GraphQL
{
    public class UsuarioSchema : Schema
    {
        public UsuarioSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<UsuarioQuery>();
        }
    }
}