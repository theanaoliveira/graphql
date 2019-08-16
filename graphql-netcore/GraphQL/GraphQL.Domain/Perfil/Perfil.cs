﻿using GraphQL.Domain.Validator;

namespace GraphQL.Domain.Perfil
{
    public class Perfil: Entity
    {
        public string Name { get; private set; }

        public Perfil(int id, string name)
        {
            Id = id;
            Name = name;

            Validate(this, new PerfilValidator());
        }
    }
}