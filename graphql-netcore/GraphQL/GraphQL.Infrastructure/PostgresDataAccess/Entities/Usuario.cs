using GraphQL.Domain.Usuario;

namespace GraphQL.Infrastructure.PostgresDataAccess.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool Vip { get; set; }
        public double Salario { get; set; }
        public virtual Perfil Perfil { get; set; }
        public UsuarioStatus Status { get; set; }
    }
}
