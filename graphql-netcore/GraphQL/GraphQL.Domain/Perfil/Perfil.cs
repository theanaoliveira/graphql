using GraphQL.Domain.Validator;
using System;

namespace GraphQL.Domain.Perfil
{
    public class Perfil: Entity
    {
        public string Name { get; private set; }

        public Perfil(Guid id, string name)
        {
            Id = id;
            Name = name;

            Validate(this, new PerfilValidator());
        }

        public Perfil()
        {
        }
    }
}
