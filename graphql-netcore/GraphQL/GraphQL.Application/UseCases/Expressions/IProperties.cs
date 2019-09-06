using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GraphQL.Application.UseCases.Expressions
{
    public interface IProperties
    {
        PropertyInfo GetProperty<T>(string field) where T : class;
    }
}
