using System;

namespace GraphQL.Domain
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
