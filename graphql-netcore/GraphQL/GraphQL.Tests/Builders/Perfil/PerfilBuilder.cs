namespace GraphQL.Tests.Builders.Perfil
{
    public class PerfilBuilder
    {
        public int Id;
        public string Name;

        public static PerfilBuilder New()
        {
            return new PerfilBuilder
            {
                Id = 1,
                Name = "Comum"
            };
        }

        public PerfilBuilder WithId(int id)
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
