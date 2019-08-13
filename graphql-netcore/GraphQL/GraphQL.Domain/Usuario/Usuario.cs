using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Domain.Usuario
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool Vip { get; set; }
    }
}
