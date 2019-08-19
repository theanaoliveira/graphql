using System;

namespace GraphQL.Tests.Builders.Perfil
{
    public class PerfilBuilder
    {
        public Guid Id;
        public string Name;

        public static PerfilBuilder New()
        {
            return new PerfilBuilder
            {
                Id = Guid.NewGuid(),
                Name = "Comum"
            };
        }

        public PerfilBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public PerfilBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public Domain.Perfil.Perfil Build()
            => new Domain.Perfil.Perfil(Id, Name);
    }
}
