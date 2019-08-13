using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Domain.Usuario
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public bool Vip { get; private set; }
        public UsuarioStatus Status { get; private set; }

        public Usuario(int id, string name, string email, int age, bool vip, UsuarioStatus status)
        {
            Id = id;
            Name = name;
            Email = email;
            Age = age;
            Vip = vip;
            Status = status;
        }
    }
}
