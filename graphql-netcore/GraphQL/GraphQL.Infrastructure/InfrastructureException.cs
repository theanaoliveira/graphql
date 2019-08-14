﻿using System;

namespace GraphQL.Infrastructure
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException(string businessMessage)
               : base(businessMessage)
        { }
    }
}
