using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Infrastructure.GraphQL.Predicates
{
    public class WhereExpression
    {
        public string Field { get; set; }
        public object Value { get; set; }
    }
}
