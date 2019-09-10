﻿using GraphQL.Application.UseCases.Expressions.Where;
using System;
using System.Linq.Expressions;

namespace GraphQL.Application.UseCases.Expressions
{
    public interface IMakeExpression
    {
        Expression<Func<T, bool>> GetExpression<T>(WhereExpression where) where T : class;
    }
}
