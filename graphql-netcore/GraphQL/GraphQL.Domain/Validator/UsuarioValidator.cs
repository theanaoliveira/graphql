using FluentValidation;

namespace GraphQL.Domain.Validator
{
    public class UsuarioValidator : AbstractValidator<Usuario.Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(r => r.Id).NotNull().GreaterThan(0);
            RuleFor(r => r.Name).NotNull().NotEmpty();
            RuleFor(r => r.Email).NotNull().NotEmpty();
            RuleFor(r => r.Age).GreaterThan(0);
            RuleFor(r => r.Salario).GreaterThan(0);
            RuleFor(r => r.Perfil).NotNull().SetValidator(new PerfilValidator());
        }
    }
}
