namespace GraphQL.Domain.Perfil
{
    public class Perfil
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Perfil(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
