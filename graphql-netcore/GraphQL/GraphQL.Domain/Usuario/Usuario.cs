using GraphQL.Domain.Validator;
using System;

namespace GraphQL.Domain.Usuario
{
    public class Usuario : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public bool Vip { get; private set; }
        public double Salario { get; private set; }
        public Guid PerfilId { get; private set; }
        public Perfil.Perfil Perfil { get; private set; }
        public UsuarioStatus Status { get; private set; }

        public Usuario(Guid id, string name, string email, int age, bool vip, double salario, Guid perfilId, Perfil.Perfil perfil, UsuarioStatus status)
        {
            Id = id;
            Name = name;
            Email = email;
            Age = age;
            Vip = vip;
            Salario = salario;
            PerfilId = perfilId;
            Perfil = perfil;
            Status = status;

            Validate(this, new UsuarioValidator());
        }

        public Usuario()
        {
        }
    }
}
