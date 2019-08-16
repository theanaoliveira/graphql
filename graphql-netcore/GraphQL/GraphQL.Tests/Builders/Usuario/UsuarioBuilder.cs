using GraphQL.Domain.Usuario;
using GraphQL.Tests.Builders.Perfil;

namespace GraphQL.Tests.Builders.Usuario
{
    public class UsuarioBuilder
    {
        public int Id;
        public string Name;
        public string Email;
        public int Age;
        public bool Vip;
        public double Salario;
        public Domain.Perfil.Perfil Perfil;
        public UsuarioStatus Status;

        public static UsuarioBuilder New()
        {
            return new UsuarioBuilder()
            {
                Id = 1,
                Name = "Ana",
                Email = "teste@graphql.com.br",
                Age = 26,
                Vip = true,
                Salario = 10000,
                Perfil = PerfilBuilder.New().Build(),
                Status = UsuarioStatus.ATIVO
            };
        }

        public UsuarioBuilder WithId(int id)
        {
            Id = id;
            return this;
        }

        public UsuarioBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public UsuarioBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public UsuarioBuilder WithAge(int age)
        {
            Age = age;
            return this;
        }

        public UsuarioBuilder WithVip(bool vip)
        {
            Vip = vip;
            return this;
        }

        public UsuarioBuilder WithSalario(double salario)
        {
            Salario = salario;
            return this;
        }

        public UsuarioBuilder WithPerfil(Domain.Perfil.Perfil perfil)
        {
            Perfil = perfil;
            return this;
        }

        public UsuarioBuilder WithStatus(UsuarioStatus status)
        {
            Status = status;
            return this;
        }

        public Domain.Usuario.Usuario Build()
            => new Domain.Usuario.Usuario(Id, Name, Email, Age, Vip, Salario, Perfil, Status);
    }
}
