using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GraphQL.Application.UseCases.Expressions
{
    public class Properties<T> where T : class
    {
        public PropertyInfo GetProperty(string field)
        {
            var properties = typeof(T).GetProperties();
            var property = properties.Where(w => w.Name.ToUpper() == field.ToUpper()).First();

            return property;
        }
    }
}
